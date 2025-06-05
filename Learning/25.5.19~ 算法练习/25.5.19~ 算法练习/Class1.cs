using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

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

