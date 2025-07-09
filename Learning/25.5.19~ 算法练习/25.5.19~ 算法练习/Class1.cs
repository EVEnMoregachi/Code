using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//public class Solution
//{
//    public int[] TwoSum(int[] nums, int target)
//    {
//        Dictionary<int, int> dic = new Dictionary<int, int>();
//        for ( int i= 0; i < nums.Length; i++)
//        {
//            dic[nums[i]] = i;
//            if (dic.ContainsKey(target - nums[i]) )
//                return new int[] { dic[target - nums[i]], i };
//            dic.Add(nums[i], i);
//        }
//        return new int[] { 0, 1 };
//    }
//}


//  public class ListNode {
//    public int val;
//    public ListNode next;
//    public ListNode(int val = 0, ListNode next = null) {
//        this.val = val;
//        this.next = next;
//    }
//}

//public class Solution
//{
//    public int[] ReverseBookList(ListNode head)
//    {
//        if (head == null)
//            return new int[0];
//        Stack<int> stack = new Stack<int>();
//        while (head.next != null)
//        {
//            stack.Push(head.val);
//            head = head.next;
//        }
//        stack.Push(head.val);
//        return stack.ToArray();

//    }
//}


//public class ListNode
//{
//    public int val;
//    public ListNode next;
//    public ListNode(int val = 0, ListNode next = null)
//    {
//        this.val = val;
//        this.next = next;
//    }
//}

//public class Solution
//{
//    public ListNode DeleteNode(ListNode head, int val)
//    {
//        ListNode temp = new ListNode();
//        if (head.val == val)
//        {
//            if (head.next == null)
//            {
//                return temp;
//            }
//            else
//            {
//                return head.next;
//            }
//        }
//        temp = head;
//        while(head.next != null)
//        {
//            if (head.next.val != val)
//            {
//                head = head.next;
//            }
//            else
//            {
//                if (head.next.next != null)
//                {
//                    head.next = head.next.next;
//                    break;
//                }
//                else
//                {
//                    head.next = null;
//                    break;
//                }
//            }
//        }
//        return temp;
//    }
//}



/// <summary>
/// 方法一 使用栈 时间复杂度 O(N)空间复杂度 O(N)
/// </summary>
//public class Solution
//{
//    public ListNode TrainningPlan(ListNode head)
//    {
//        if (head == null)
//            return head;
//        Stack<int> stack = new Stack<int>();
//        while (head.next != null)
//        {
//            stack.Push(head.val);
//            head = head.next;
//        }
//        stack.Push(head.val);
//        ListNode newhead = new ListNode();
//        ListNode temp = new ListNode();
//        newhead = temp;
//        while(stack.Count > 0)
//        {
//            temp.val = stack.Pop();
//            temp.next = null;
//            if (stack.Count > 0)
//            {
//                temp.next = new ListNode();
//                temp = temp.next;
//            }

//        }
//        return newhead;
//    }
//}
/// <summary>
/// 法二 双指针 时间复杂度 O(N)空间复杂度 O(1)
/// </summary>
//public class Solution
//{
//    public ListNode TrainningPlan(ListNode head)
//    {
//        if (head == null)
//            return head;
//        ListNode cur = head;
//        ListNode pre = null;
//        ListNode temp = new ListNode();

//        while (cur.next != null)
//        {
//            temp = cur.next;
//            cur.next = pre;
//            pre = cur;
//            cur = temp;
//        }
//        cur.next = pre;

//        return cur;
//    }
//}


//利用了栈 时间复杂度O(n) 空间复杂度O(n)
//public class Solution
//{
//    public ListNode TrainingPlan(ListNode head, int cnt)
//    {
//        if (head == null) return null;
//        Stack<ListNode> stack = new Stack<ListNode>();
//        while (head.next != null)
//        {
//            stack.Push(head);
//            head = head.next;
//        }
//        stack.Push(head);
//        while(cnt > 1)
//        {
//            stack.Pop();
//            cnt--;
//        }
//        return stack.Peek();
//    }
//}

////使用双指针 时间复杂度O(n) 空间复杂度O(1)
//public class Solution
//{
//    public ListNode TrainingPlan(ListNode head, int cnt)
//    {
//        if (head == null) return null;
//        ListNode headNode = head;
//        int size = 0;
//        while (head != null)
//        {
//            size++;
//            head = head.next;
//        }
//        for (int i = 0; i < size - cnt; i ++)
//        {
//            headNode = headNode.next;
//        }
//        return headNode;
//    }
//}




//递归 时间复杂度O(N+M) 空间复杂度O(N+M)
//public class Solution
//{
//    public ListNode TrainningPlan(ListNode l1, ListNode l2)
//    {
//        if (l1 == null && l2 == null) return null;
//        else if (l1 == null) return l2;
//        else if (l2 == null) return l1;

//        ListNode newlist = null;
//        if (l1.val < l2.val)
//        {
//            newlist = l1;
//            newlist.next = TrainningPlan(l1.next, l2);
//        }
//        else
//        {
//            newlist = l2;
//            newlist.next = TrainningPlan(l1, l2.next);
//        }
//        return newlist;
//    }
//}


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        this.val = x;
    }
}

//public class Solution
//{
//    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
//    {
//        ListNode curA = headA;
//        ListNode curB = headB;
//        while (curA != curB)
//        {
//            curA = curA.next == null ? headB : curA.next;
//            curB = curB.next == null ? headA : curB.next;
//        }
//        return curA;
//    }
//}


//public class Node
//{
//    public int val;
//    public Node next;
//    public Node random;

//    public Node(int _val)
//    {
//        val = _val;
//        next = null;
//        random = null;
//    }
//}

//public class Solution
//{
//    public Node CopyRandomList(Node head)
//    {
//        if (head == null) return null;
//        Dictionary<Node, Node> dic = new Dictionary<Node, Node>();
//        Node node = head;
//        while (node != null)
//        {
//            dic.Add(node, new Node(node.val));
//            node = node.next;
//        }
//        node = head;
//        while (node != null)
//        {
//            if (node.next != null) dic[node].next = dic[node.next];
//            if (node.random != null) dic[node].random = dic[node.random];
//            node = node.next;
//        }
//        return dic[head];
//    }
//}


//public class Solution
//{
//    public int[] TrainingPlan(int[] actions)
//    {
//        int a = 0; 
//        int b = actions.Length - 1;
//        int tmp;
//        while (a < b)
//        {
//            if (actions[b] % 2 == 1)
//            {
//                if (actions[a] % 2 == 1)
//                {
//                    a++;
//                    continue;
//                }
//                else
//                {
//                    tmp = actions[a];
//                    actions[a] = actions[b];
//                    actions[b] = tmp;
//                }
//            }
//            else
//            {
//                if (actions[a] % 2 == 1)
//                {
//                    a++;
//                    b--;
//                    continue;
//                }
//                else
//                {
//                    b--;
//                    continue;
//                }
//            }
//        }
//        return actions;
//    }
//}

//public class Solution
//{
//    public int[][] FileCombination(int target)
//    {
//        int a = 1, b = 2, sum = 3;
//        List<int[]> result = new List<int[]>();
//        while (a < b)
//        {
//            if (sum == target)
//            {
//                int[] ans = new int[b - a + 1];
//                for (int i = a; i <= b; i++)
//                {
//                    ans[i - a] = i;
//                }
//                result.Add(ans);
//                sum -= a++;
//            }
//            else if (sum < target)
//            {
//                sum += ++b;
//            }
//            else
//            {
//                sum -= a++;
//            }
//        }
//        return result.ToArray();
//    }
//}


//public class Solution
//{
//    public int[] StatisticalResult(int[] arrayA)
//    {
//        int total = 1;
//        int zeroIdx = -1;
//        bool tooManyZero = false;
//        int[] result = new int[arrayA.Length];
//        for (int i = 0; i < arrayA.Length; i++)
//        {
//            if (arrayA[i] == 0)
//            {
//                if (zeroIdx != -1)
//                {
//                    tooManyZero = true;
//                }
//                if (zeroIdx == -1)
//                {
//                    zeroIdx = i;
//                }
//                continue;
//            }
//            total *=  arrayA[i];
//        }
//        if (tooManyZero)
//        {
//            for (int i = 0; i < arrayA.Length; i++)
//            {
//                result[i] = 0;
//            }
//        }
//        else
//        {
//            if (zeroIdx == -1)
//            {
//                for (int i = 0; i < arrayA.Length; i++)
//                {
//                    result[i] = total / arrayA[i];
//                }
//            }
//            else
//            {
//                for (int i = 0; i < arrayA.Length; i++)
//                {
//                    if (i == zeroIdx)
//                    {
//                        result[i] = total;
//                    }
//                    else
//                    {
//                        result[i] = 0;
//                    }
//                }
//            }
//        }
//        return result;
//    }
//}

//public class Solution
//{
//    public int FindRepeatDocument(int[] documents)
//    {
//        HashSet<int> arr = new HashSet<int>();
//        for (int i = 0; i < documents.Length; i++)
//        {
//            if (arr.Contains(documents[i]))
//            {
//                return documents[i];
//            }
//            else
//            {
//                arr.Add(documents[i]);
//            }
//        }
//        return 0;
//    }
//}
//public class Solution
//{
//    public int[] SpiralArray(int[][] array)
//    {
//        if (array.Length == 0) return new int[0];
//        int[] result = new int[array.Length * array[0].Length];
//        int idx = 0;
//        int t = 0, l = 0, b = array.Length - 1, r = array[0].Length - 1;
//        while (true)
//        {
//            for (int i = l; i <= r; i++)
//            {
//                result[idx++] = array[t][i];
//            }
//            //上边界和下边界重合的时候
//            if (t++ == b) break;
//            for (int i = t; i <= b; i++)
//            {
//                result[idx++] = array[i][r];
//            }
//            if (r-- == l) break;
//            for (int i = r; i >= l; i--)
//            {
//                result[idx++] = array[b][i];
//            }
//            if (b-- == t) break;
//            for (int i  = b; i >= t; i--)
//            {
//                result[idx++] = array[i][l];
//            }
//            if (l++ == r) break;
//        }
//        return result;
//    }
//}


//public class Solution
//{
//    public string PathEncryption(string path)
//    {
//        var result = path.ToCharArray();

//        for (int i = 0; i < result.Length; i++)
//        {
//            if (result[i] == '.')
//            {
//                result[i] = ' ';
//            }
//        }
//        return new string(result);
//    }
//}

//public class Solution
//{
//    public string ReverseMessage(string message)
//    {
//        message = message.Trim();
//        if (message.Length == 0) return "";
//        message = " " + message;
//        StringBuilder sb = new StringBuilder();
//        int r = message.Length - 1, l = r - 1;
//        bool selected = false;
//        while (r != -1)
//        {
//            for (l = r - 1; l >= 0; l--)
//            {
//                if (message[l] == ' ' && !selected)
//                {
//                    sb.Append(message.Substring(l + 1, r - l) + " ");
//                    selected = true;
//                    r = l - 1;
//                    continue;
//                }
//                if (selected && (message[l] != ' '))
//                {
//                    r = l;
//                    selected = false;
//                    break;
//                }
//            }
//        }
//        return sb.ToString().Trim();
//    }
//}

//public class Solution
//{
//    public string DynamicPassword(string password, int target)
//    {
//        string pur = password.Substring(0, target);
//        string res = password.Substring(target);
//        return res + pur;
//    }
//} 

//public class Solution
//{
//    public int MyAtoi(string str)
//    {
//        str = str.Trim();
//        if (str.Length == 0) return 0;
//        switch (str[0])
//        {
//            case '+':
//                return GetDegital(str.Substring(1), true);
//                break;
//            case '-':
//                return GetDegital(str.Substring(1), false);
//                break;
//            default:
//                return GetDegital(str, true);
//                break;
//        }
//    }

//    private int StringToInt(string str, bool v)
//    {
//        long x = 0;
//        for (int i = str.Length - 1; i >= 0; i--)
//        {
//            if (v)
//            {
//                x += (str[i] - '0') * (long)Math.Pow(10, str.Length - i - 1);
//                if (x > int.MaxValue || Math.Pow(10, str.Length - i - 1) > int.MaxValue && (str[i] - '0') > 0)
//                    return int.MaxValue;
//            }
//            else
//            {
//                x -= (str[i] - '0') * (long)Math.Pow(10, str.Length - i - 1);
//                if (x < int.MinValue || -Math.Pow(10, str.Length - i - 1) < int.MinValue && (str[i] - '0') > 0)
//                    return int.MinValue;
//            }
//        }
//        return (int)x;
//    }

//    private int GetDegital(string str, bool v)
//    {
//        for (int i = 0; i < str.Length; i++)
//        {
//            if (str[i] < '0' || str[i] > '9')
//            {
//                return StringToInt(str.Substring(0, i), v);
//            }
//            if (i == str.Length - 1)
//            {
//                return StringToInt(str, v);
//            }
//        }
//        return 0;
//    }
//}



//public class Solution
//{
//    public bool ValidNumber(string s)
//    {
//        s = s.Trim();
//        if (s.Length == 0) return false;

//        bool findE = false;             //找到e
//        bool findDot = false;           //找到.
//        bool findDigit = false;         //找到数字
//        bool findDigitAfterE = false;   //找到e后的数字

//        for (int i = 0; i < s.Length; i++)
//        {
//            if (s[i] >= '0' && s[i] <= '9')
//            {
//                findDigit = true;
//                if (findE) findDigitAfterE = true;
//            }
//            else if (s[i] == '.')
//            {   //e后必须是整数 只能有一个.
//                if (findDot || findE) return false;
//                findDot = true;
//            }
//            else if (s[i] == 'e' || s[i] == 'E')
//            {   //e只能出现一次，且前面必须有数字
//                if (findE || !findDigit) return false;
//                findE = true;
//            }
//            else if (s[i] == '-' || s[i] == '+')
//            {   //加减号只能出现的开始或者e之后
//                if (i != 0 && s[i - 1] != 'e' && s[i - 1] != 'E') return false;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        // 如果找到了e,那么返回是否找到了e后的数字，否则返回是否找到了数字
//        return findE ? findDigitAfterE : findDigit;
//    }
//}

//// 正则表达式解法
//using System.Text.RegularExpressions;
//public class Solution
//{
//    public bool ValidNumber(string s)
//    {
//        if (s == null)
//            return false;

//        // 正则表达式匹配有效数字
//        // 允许：
//        // 1. 可选的正负号 [+-]?
//        // 2. 数字部分可以是：
//        //    - 整数（如 123）
//        //    - 小数（如 123.456 或 .456 或 123.）
//        // 3. 可选的指数部分（如 e10 或 E-10）
//        // 4. 允许前后有空白字符 \s*
//        string pattern = @"^\s*[+-]?(\d+\.\d*|\.\d+|\d+)([eE][+-]?\d+)?\s*$";
//        return Regex.IsMatch(s, pattern);
//    }
//}


//public class CQueue
//{
//    Stack<int> stack1, stack2;
//    public CQueue()
//    {
//        stack1 = new Stack<int>();
//        stack2 = new Stack<int>();
//    }

//    public void AppendTail(int value)
//    {
//        stack1.Push(value);
//    }

//    public int DeleteHead()
//    {
//        if (stack2.Count > 0) return stack2.Pop();
//        if (stack1.Count == 0) return -1;
//        while (stack1.Count > 0)
//        {
//            stack2.Push(stack1.Pop());
//        }
//        return stack2.Pop();
//    }
//}

//public class MinStack
//{
//    Stack<int> stackA, stackB;

//    public MinStack()
//    {
//        this.stackA = new Stack<int>();
//        this.stackB = new Stack<int>();
//    }

//    public void Push(int x)
//    {
//        if (stackA.Count == 0)
//        {
//            stackA.Push(x);
//            stackB.Push(x);
//            return;
//        }
//        stackA.Push(x);
//        if (x < stackB.Peek())
//            stackB.Push(x);
//        else
//            stackB.Push(stackB.Peek());
//    }

//    public void Pop()
//    {
//        stackA.Pop();
//        stackB.Pop();
//    }

//    public int Top()
//    {
//        return stackA.Peek();
//    }

//    public int GetMin()
//    {
//        return stackB.Peek();
//    }
//}

//public class Solution
//{
//    public bool ValidateBookSequences(int[] putIn, int[] takeOut)
//    {
//        Stack<int> stack = new Stack<int>();
//        int idx = 0;
//        for (int i = 0; i < putIn.Length; i++)
//        {
//            if (putIn[i] == takeOut[idx])
//            {
//                idx++;
//                continue;
//            }
//            if(stack.Count > 0)
//            {
//                if (stack.Peek() == takeOut[idx])
//                {
//                    stack.Pop();
//                    idx++;
//                    i--;
//                    continue;
//                }
//            }
//            stack.Push(putIn[i]);
//        }
//        if (stack.Count > 0)
//        {
//            for (int i = idx; i < takeOut.Length; i++)
//            { 
//                if (stack.Pop() != takeOut[i])
//                {
//                    return false;
//                }
//            }
//        }
//        return stack.Count == 0;
//    }
//}


//public class Solution
//{
//    LinkedList<int> deque = new LinkedList<int>();
//    public int[] MaxAltitude(int[] heights, int limit)
//    {
//        int r, idx = 0;
//        int[] result = new int[heights.Length - limit + 1];
//        if (heights.Length == 0 || limit <= 0) return new int[0];
//        for (int l = 0; l <= heights.Length - limit; l++)
//        {
//            r = l + limit - 1;
//            if (deque.Count == 0)
//            {
//                deque = GetList(heights, l, r);
//                result[idx++] = deque.Last.Value;
//                continue;
//            }
//            else//如果先前窗口有值
//            {
//                if (deque.First.Value == heights[l - 1])//更新窗口左端
//                {
//                    deque.RemoveFirst();
//                }
//                if (deque.Count == 0)
//                {
//                    deque = GetList(heights, l, r);
//                    result[idx++] = deque.Last.Value;
//                    continue;
//                }
//                if (deque.Last.Value < heights[r])
//                {
//                    deque.AddLast(heights[r]);
//                }
//                result[idx++] = deque.Last.Value;
//            }
//        }
//        return result;
//    }
//
//    public LinkedList<int> GetList(int[] arr, int l, int r)
//    {
//        LinkedList<int> newList = new LinkedList<int>();
//        newList.AddLast(arr[l]);
//        for (int i = l + 1; i <= r; i++)
//        {
//            if (newList.Last.Value < arr[i])
//            {
//                newList.AddLast(arr[i]);
//            }
//        }
//        return newList;
//    }
//}

//public class Checkout
//{
//    LinkedList<int> list;
//    Queue<int> queue;
//    public Checkout()
//    {
//        list = new LinkedList<int>();
//        queue = new Queue<int>();
//    }

//    public int Get_max()
//    {
//        return list.Count > 0 ? list.First.Value : -1;
//    }

//    public void Add(int value)
//    {
//        queue.Enqueue(value);
//        if (list.Count <= 0)
//        {
//            list.AddLast(value);
//            return;
//        }
//        while (true)
//        {
//            if (list.Count <= 0)
//            {
//                list.AddLast(value);
//                break;
//            }
//            if (value > list.Last.Value)
//            {
//                list.RemoveLast();
//            }
//            else
//            {
//                list.AddLast(value);
//                break;
//            }
//        }
//    }

//    public int Remove()
//    {
//        if (queue.Count == 0) return -1;
//        if (list.Count > 0)
//            if (list.First.Value == queue.Peek())
//            {
//                list.RemoveFirst();
//            }
//        return queue.Dequeue();
//    }
//}

public class Solution
{
    
    Dictionary<char, int> dic = new Dictionary<char, int>();
    public char DismantlingAction(string arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            char v = arr[i];
            dic[v] = dic.ContainsKey(v) ? dic[v] + 1 : 1;
        }
        for (int i = 0; i < arr.Length; i++)
        {
            if (dic[arr[i]] == 1)
            {
                return arr[i];
            }
        }
        return ' ';
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] x = solution.MaxAltitude(new int[] { 14, 2, 27, -5, 28, 13, 39 }, 3);
        Console.WriteLine(x);
        Console.Read();
    }
}