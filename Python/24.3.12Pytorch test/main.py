import torch
import torch.nn as nn
import torch.nn.functional as F
import torch.optim as optim
from torchvision import datasets, transforms

#定义超参数
BATCH_SIZE = 64 #每批处理的数据
DEVICE = torch.device("cuda" if torch.cuda.is_available() else "cpu") #如果可以用gpu使用gpu否则使用cpu
EPOCHS = 10 #训练数据集的轮次

#构建pipeline ，对图像做处理
pipeline = transforms.Compose([
    transforms.ToTensor(),#把图片转换成tenser
    transforms.Normalize((0.1307,),(0.3081,))#标准化，均值变为0，标准差变为1，有助于提高模型的稳定性和收敛速度
])

#下载、加载数据
from torch.utils.data import DataLoader
#下载数据集
##训练集
train_set = datasets.MNIST("data", train=True, download=True, transform=pipeline)
##测试集
test_set = datasets.MNIST("data", train=False, download=True, transform=pipeline)

#加载数据
train_loader = DataLoader(train_set, batch_size=BATCH_SIZE, shuffle=True) #shuffle打乱
test_loder = DataLoader(test_set, batch_size=BATCH_SIZE, shuffle=True)

# #显示MNIST中的图片
# with open("./data/MNIST/raw/train-images-idx3-ubyte", "rb") as f:
#     file = f.read()
# image1 = [int(str(item).encode('ascii'), 16) for item in file[16: 16+784]]
# #print(image1)
# import cv2
# import numpy as np
# image1_np = np.array(image1, dtype=np.uint8).reshape(28, 28, 1)
# print(image1_np.shape)
# cv2.imwrite("digit.jpg",image1_np)

#构建网络模型
class Digit(nn.Module):
    def __init__(self):
        super().__init__()
        self.conv1 = nn.Conv2d(1, 10, 5) #1：图片的颜色通道 10：输出通道 5：卷积核kernel
        self.conv2 = nn.Conv2d(10, 20, 3)
        self.fc1 = nn.Linear(20*10*10, 500)
        self.fc2 = nn.Linear(500, 10)

    def forward(self, x):
        input_size = x.size(0)
        x = self.conv1(x) #输入batch size*1*28*28 输出batch size*10*24*24（28-5）/1+1
        x = F.relu(x) #保持shpae不变，输出batch size*10*24*24
        x = F.max_pool2d(x, 2, 2) #输入batch size*10*24*24 输出batch size*10*12*12
        x = self.conv2(x) #输出batch size*20*10*10（12-3+1）
        x = F.relu(x)
        x = x.view(input_size, -1) #拉伸 -1自动计算维度 20*10*10=2000
        x = self.fc1(x) #输入batch*2000 输出batch*500
        x = F.relu(x)
        x = self.fc2(x) # 500→10

        output = F.log_softmax(x, dim=1) #计算分类后 每个数字的概率
        return output

#定义优化器
model = Digit().to(DEVICE)
optimizer = optim.Adam(model.parameters())

#定义训练方法
def train_model(model, device, train_loader, optimizer, epoch):
    #模型训练
    model.train()
    for batch_index,(data, target) in enumerate(train_loader):
        #部署到DEVICE
        data, target = data.to(device), target.to(device)
        #梯度初始化为0
        optimizer.zero_grad()
        #训练后的结果
        output = model(data)
        #计算损失
        loss = F.cross_entropy(output, target)
        # #找到概率值最大的下标
        # pred = output.max(1, keepdim=True)
        #反向传播
        loss.backward()
        #参数优化
        optimizer.step()
        if batch_index % 3000 == 0:
            print("Train Epoch: {} \t Loss : {:.6f}".format(epoch, loss.item()))

#定义测试方法
def test_model(model, device, test_loader):
    #模型验证
    model.eval()
    #正确率
    correct = 0.0
    #测试损失
    test_loss = 0.0
    with torch.no_grad():
        for data, target in test_loader:
            #部署到device上
            data, target = data.to(device), target.to(device)
            #测试数据
            output = model(data)
            #计算测试损失
            test_loss += F.cross_entropy(output, target).item()
            # 找到概率值最大的下标
            pred = output.max(1, keepdim=True)[1] #值 索引
            #pred = torch.max(output, dim = 1)
            #pred = output.argmax(dim = 1)
            #累计正确率
            correct += pred.eq(target.view_as(pred)).sum().item()
        test_loss /= len(test_loader.dataset)
        print("Test -- Average loss: {:.4f} Accuracy : {:.3f}\n".format(test_loss, 100.0 * correct / len(test_loader.dataset)))

#调用方法
for epoch in range(1, EPOCHS + 1):
    train_model(model, DEVICE, train_loader, optimizer, epoch)
    test_model(model, DEVICE, train_loader)