using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.Stacks
{
    public class Implement2StacksInArray : IVerifyProgram
    {
        private int S1;
        private int S2;
        private int S1_Size;
        private int S2_Size;
        private int Size;
        public int[] StackArr;

        public void VerifyProgram()
        {
            // 1. Test push and pop on an empty stack
            // 2. Test push to full stack
            // 3. Test pop to empty stack
            // 4. Test push again from an emptied stack
            // 5. Test boundary conditions like testing with just 2 elements. Less than 2 elements etc.

            // 1.
            Implement2StacksInArray stack = new Implement2StacksInArray();
            int s1_val = 0; int s2_val = 0;
            stack.Create(6);
            stack.Push(1, 10);
            stack.Pop(ref s1_val, ref s2_val);
            Debug.Assert(s1_val == 1); Debug.Assert(s2_val == 10);

            // 2.
            stack.Push(1, 10); stack.Push(2, 11); stack.Push(3, 12);
            try { stack.Push(4, 13); }
            catch (Exception ex) { Debug.Assert(ex.Message.Contains("full")); }

            // 3.
            stack.Pop(ref s1_val, ref s2_val); Debug.Assert(s1_val == 3); Debug.Assert(s2_val == 12);
            stack.Pop(ref s1_val, ref s2_val); Debug.Assert(s1_val == 2); Debug.Assert(s2_val == 11);
            stack.Pop(ref s1_val, ref s2_val); Debug.Assert(s1_val == 1); Debug.Assert(s2_val == 10);
            try { stack.Pop(ref s1_val, ref s2_val); }
            catch (Exception ex) { Debug.Assert(ex.Message.Contains("empty")); }

            // 4.
            stack.Push(1, 10); stack.Pop(ref s1_val, ref s2_val);
            Debug.Assert(s1_val == 1); Debug.Assert(s2_val == 10);

            // 5.
            stack.Create(2);
            stack.Push(1, 10);
            try { stack.Push(2, 11); }
            catch (Exception ex) { Debug.Assert(ex.Message.Contains("full")); }

            Debug.Assert(stack.Create(1) == false);
        }

        public bool Create(int size)
        {
            if (size / 2 < 1) return false;
            Size = size;
            S1 = -1; S1_Size = (size / 2) - 1;
            S2 = (size / 2) - 1; S2_Size = size - 1;
            StackArr = new int[size];
            return true;
        }

        public void Push(int s1_val, int s2_val)
        {
            if (S1 == S1_Size) throw new Exception("Stack 1 full");
            if (S2 == S2_Size) throw new Exception("Stack 2 full");
            StackArr[++S1] = s1_val;
            StackArr[++S2] = s2_val;
        }

        public void Pop(ref int s1_val, ref int s2_val)
        {
            if (S1 == -1) throw new Exception("Stack 1 empty");
            if (S2 == (Size /2) - 1) throw new Exception("Stack 2 empty");
            s1_val = StackArr[S1--];
            s2_val = StackArr[S2--];
        }
    }
}
