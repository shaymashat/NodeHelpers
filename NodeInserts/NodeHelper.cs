using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NodeClass
{
    internal class NodeHelper
    {
        #region IsExists
        public static bool IsExists<T>(Node<T> list, T value)
        {
            while(list!=null)
            {
                if (list.GetValue().Equals(value))
                    return true;
                list = list.GetNext();
            }
            return false; 
        }
        #endregion

        #region Count Nodes
        public static int CountList<T>(Node<T> head)
        {
            int counter = 0;
            while (head != null)
            {
                counter++;
                head = head.GetNext();//i++
            }
            return counter;
        }
        #endregion

        #region IsSorted
        public static bool IsSorted(Node<int> ls)
        {
            //כל עוד יש שתי חוליות בשרשרת
            while (ls != null && ls.HasNext())
            {
                //אם לא ממוין

                #region אופציה נוספת
                //Node<int> next=ls.GetNext();
                //if(ls.GetValue()>next.GetValue())
                //return false;
                #endregion
                if (ls.GetValue() > ls.GetNext().GetValue())
                    return false;
                //נתקדם הלאה (כמו לקדם אינדקס במערך
                ls = ls.GetNext();
            }
            return true;
        }
        #endregion

        #region -------------------------------------------
        #endregion

        #region Add To Start
        public static void AddAfterNode1<T>(Node<T> node,T value)
        {
            node.SetNext(new Node<T>(value, node.GetNext()));
        }
        #endregion
        #region Add to End
        public static void Append<T>(Node<T> lst,T value)
        {
           //find last node
            while(lst.HasNext())
            {
                lst = lst.GetNext();
            }
            //add a new node after it
            lst.SetNext(new Node<T>(value));
        }
        #endregion

        #region Add To Middle In Sorted Linked Nodes
        public static void AddToMiddle(Node<int> lst, int val)
        {
            Node<int> toInsert=new Node<int>(val);
            //find the location to insert the node
            while(lst.HasNext()&&lst.GetValue()>lst.GetNext().GetValue())
            {
                lst = lst.GetNext();
            }
            //connect the new node to the list
            toInsert.SetNext(lst.GetNext());
            //connect the "before Node" to the new node
            lst.SetNext(toInsert);

        }
        #endregion
        #region Excersise
        public static void AddAfterValue<T>(Node<T> lst,T after,T value)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Create Methods
        public static Node<double> CreateDoubleList()
        {
           throw new NotImplementedException("To Do"); 
        }
        public static Node<int> CreateIntList(int from, int to, int quantity)
        {
            Random rnd = new Random();
            Node<int> head=new Node<int>(rnd.Next(from,to+1));
            //#region Add To Tail
            //Node<int> tail = head;
            //for(int i=2;i<=quantity;i++)
            //{
            //    Node<int> toInsert = new Node<int>(rnd.Next(from, to + 1));
            //    tail.SetNext(toInsert);
            //    tail=tail.GetNext(); 
            //}
            //#endregion

            #region Add To Head
            for (int i = 2; i <= quantity; i++)
                head = new Node<int>(rnd.Next(from, to + 1), head);

                #endregion

                return head;


        }
        public static Node<int> CreateRecursiveList(Node<int> ls,int from,int to, int count)
        {
            throw new NotImplementedException("To Do"); 
        }
        #endregion


        #region Delete

        public static Node<T> DeleteWithDummy<T>(Node<T> list,T val)
        {
            Node<T> dummy = new Node<T>(default(T), list);

            Node<T> next = dummy.GetNext();
            Node<T> current = dummy;
            while (next != null && !next.GetValue().Equals(val))
            {
                current = current.GetNext();
                next = current.GetNext();
            }
            //מצאתי את הערך!!!!
            if (next != null)
            {
                current.SetNext(next.GetNext());
                next.SetNext(null);


            }
            return dummy.GetNext();
        }
        /// <summary>
        /// פעולה שמוחקת את החוליה שיש את הערך 
        /// val
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static Node<T> Delete<T>(Node<T> list,  T val)
        {
            //לא לשכוח לשמור על הראש
            Node<T> head = list;
            //יש מאיפה למחוק
            if (list != null)
            {
                //נבדוק האם הערך נמצא בחוליה הראשונה
                if(list.GetValue().Equals(val))
                {
                    //נעדכן ראש חדש
                    head = list.GetNext();
                    //ננתק את הראש הישן
                    list.SetNext(null);
                }
                //הערך נמצא בחוליה בהמשך
                else
                {
                    //נחפש את החוליה שמכילה את הערך

                    //while(list.HasNext()&&!list.GetNext().GetValue().Equals(val))
                    Node<T> next=list.GetNext();
                    while (next != null && !next.GetValue().Equals(val))
                    {
                        list = list.GetNext();
                        next = list.GetNext();
                    }
                    //מצאתי את הערך!!!!
                    if(next!=null)
                    {
                        list.SetNext(next.GetNext());
                        next.SetNext(null);


                    }
                }
            }
             return head;
        }
        /// <summary>
        /// פעולה המוחקת את החוליה העוקבת
        /// </summary>
        /// <param name="node"></param>
        /// <returns>מחזירה את החוליה שנמחקה</returns>
        public static Node<T> DeleteAfterNode<T>(Node<T> node )
        {
           throw new NotImplementedException();
        }


        #endregion

        #region Excercises

        public static Node<T> Reverse<T>(Node<T> lst)
        {
            #region לשמור על הראש
            //האם יש ראש חדש/סריקה חוזרת?
            Node<T> head = lst;
            Node<T> tail = lst;
            #endregion

            #region לא ליפול בנאל
            if (lst == null)
                return null;
            //האם בודקים רק ערך של חוליה אחת או של שתיים?
            while(tail.HasNext())
            {
            #region להעזר בחברים
            //במחיקה והוספה כדאי להעזר משתנים שמצביעים על הקודם ועל זה שנוסיף/נמחק
            Node<T> next=tail.GetNext();
                tail.SetNext(next.GetNext());
                next.SetNext(head);
                head = next;

            #endregion

            }


            #endregion
            return head;
            
        }

        public static Node<T> ReverseWithDummy<T>(Node<T>lst)
        {

            //ניצור חוליה פיקטיבית
            Node<T> dummy = new Node<T>(default(T), lst);
            
            while(lst.HasNext())
            {
                //נעזר בחבר שיצביע על החוליה שיש לנתק
                Node<T> nxt = lst.GetNext();
                
                lst.SetNext(nxt.GetNext());//ננתק מצד שמאל
                nxt.SetNext(dummy.GetNext());//נחבר/ננתק מצד ימין
                dummy.SetNext(nxt);//נחבר את הראש החדש
            }
            
            //נגיע לשורה זו כשהראש הישן הגיע לסוף
            return dummy.GetNext();//נחזיר את הראש המעודכן

        }

        public static bool IsEqual<X>(Node<X> ls1, Node<X> ls2)
        {
            while (ls1 != null && ls2 != null)
            {
                if (!ls1.GetValue().Equals(ls2.GetValue()))
                    return false;
                ls1 = ls1.GetNext();
                ls2 = ls2.GetNext();
            }
            //יחזיר אמת אם שתי הרשימות הגיעו לסוף
            //ושקר אחרת
            return (ls1 == null && ls2 == null);
        }

        #endregion
        //שאלה 2
        public static int Return(Node<int> list, int num)
        {
            Node<int> head = list;
            int count = 0;
            while (head.HasNext() == true)
            {
                if (list.GetValue()==num &&head.GetValue()!=num)
                {
                    count++;
                    list=head;
                    head=list.GetNext();
                }
            }
            if(list.GetValue()==num&&list.GetNext()==null) { count++; }
            return count;
        }
        //Question 4
        public static char Four(Node<int> list)
        {
            int countZ = 0;
            int countE = 0;
            while (list != null)
            {
                if (list.GetValue() % 2 == 0)
                {
                    countZ++;
                }
                if (list.GetValue() % 2 != 0)
                {
                    countE++;
                }
                list = list.GetNext();
            }
            if (countZ > countE)
            {
                return 'z';
            }
            if (countE > countZ)
            {
                return 'e';
            }

            return 's';
        }
        //Question 6
        public static Node<T> Double<T>(Node<T> node)
        {
           Node<T> head = node; 
            while (node!=null)
            {
                head = node.GetNext();
                while (node != null)
                {
                    Node<T> currentnode = node.GetNext();
                    if (!node.GetValue().Equals(currentnode.GetValue()))
                    {
                        currentnode.SetNext(head.GetNext());
                        currentnode.SetNext(null);
                    }
                    currentnode = currentnode.GetNext();
                }
                node.SetNext(head);
            }

            return head;
        }
        //Question 8
        public static bool IsAscending(Node<int> list)
        {
            while (list.HasNext())
            {
                if (list.GetValue() > list.GetNext().GetValue())
                {
                    return false;
                }
                list = list.GetNext();
            }
            return true;
        }
        //Question 10
        public static Node<int> Sidra(int begginer,int num)
        {
            Node<int> list = new Node<int>(begginer);
            Node<int> head = list;
           for(int i = 1; i <= num; i++)
            {
                Node<int> next = new Node<int>(begginer + i);
                list.SetNext(next);
                head = next;
            }
           return head;
        }
        //Question 14
        //פעולת עזר
        public static Node<int> delete(Node<int> head)
        {
            int biggestNum = int.MinValue;
            int biggestIndex = 0;
            int index = 0;
            Node<int> newNode = head;
            while (newNode != null)
            {
                if (newNode.GetValue() > biggestNum) { biggestNum = newNode.GetValue(); biggestIndex = index; }
                index++;
                newNode = newNode.GetNext();
            }
            if (biggestIndex == 0) { return head.GetNext(); }
            Node<int> newNode2 = head;
            for (int i = 0; i < biggestIndex - 1; i++)
            {
                newNode2 = newNode2.GetNext();
            }
            newNode2.SetNext(newNode2.GetNext().GetNext());
            return head;
        }
        public static Node<int> Ex14(Node<int> head, int n)
        {
            for (int i = 0; i < n; i++)
            {
                head = delete(head);
            }
            return head;
        }

        public static Node<T> WithoutDuplicate<T>(Node<T> lst)
        {
            if (lst == null)
                return null;
            Node<T> head=new Node<T>(lst.GetValue());
            Node<T> tail = head;
            lst=lst.GetNext();
            while (lst != null)
            {
                if (!IsExists(head, lst.GetValue()))
                {
                    tail.SetNext(new Node<T>(lst.GetValue()));
                    tail=tail.GetNext();
                }
                lst=lst.GetNext();
            }
            return head;
        }
        //Question 32
        public static int Ex32(Node<int> lis1, Node<int> lis2) 
        {
            int count = 0;
            int count2 =0;
            Node<int> head1 = lis1;
            Node<int> head2 = lis2;
            while (lis1.GetNext()!=null)
            {
                count++;
                lis1=lis1.GetNext();
            }
            while (lis2.GetNext() != null)
            {
                count2++;
                lis2=lis2.GetNext();
            }
            if (count > count2)
                return -1;
            if (count2 > count)
                return -2;
            if (count == count2)
            {
                while (lis1.GetNext() != null)
                {
                   head1 = lis1.GetNext();
                    head2 = lis2.GetNext();
                    if (head1.GetValue() > head2.GetValue())
                    {
                        return -1;
                    }
                    else
                        return -2;

                }
            }
            return 0;
        }
        //Question 33

        //public static Node<int> Ex33(Node<int> lis1,Node<int> lis2)
        //{
        //    Node<int> head = lis1;
        //    Node<int> head2 = lis2;
        //    while (lis1.GetNext()!=null)
        //    {
        //        head = lis1.GetNext();
        //        head2 = lis2.GetNext();

        //    }
        //}

       public static Node<T> Merge<T>(Node<T> lst1,Node<T> lst2)
        {
            Node<T> head1= lst1;
            Node<T> head2= lst2;
            Node<T> Newlst=new Node<T> (lst1.GetValue());
           for(int i=0; i<CountList(lst1); i++)
            {
                if (i % 2 != 0)
                {
                    head1.SetNext(Newlst);
                }
                else
                    head2.SetNext(Newlst);
            }
           return Newlst as Node<T>;
        }

        #region כפילויות

        public static int CountNoOfDuplication(Node<int> head, int x)
        {
            //אם הרשימה ריקה
            if (head == null)
                return 0;
            //ניצור מונה
            int count = 0;
            //כל עוד יש איברים ברשימה
            while (head != null)
            {
                //נחפש את המופע  הראשון של 
                //x
                while (head != null && head.GetValue() != x)
                {
                    head = head.GetNext();
                }
                //אם לא הגענו לסוף הרשימה
                if (head != null)
                {
                    count++; //מצאנו רצף
                             //נדלג על הרצף
                    while (head.HasNext() && head.GetNext().GetValue() == x)
                    {
                        head = head.GetNext();
                    }
                    //נעצור 
                    //או כשהבא הוא כבר חוליה לא על הרצף
                    //או שאנחנו ברצף אבל הגענו לחוליה האחרונה

                    head = head.GetNext();
                }
            }
            return count;
        }
        public static int CountNoOfDuplicationV2(Node<int> head, int x)
        {
            //ניצור חוליה ראשונה פיקטיבית
            Node<int> dummy = new Node<int>(0, head);
            //ניצור 2 מצביעים לנוכחי ולבא
            Node<int> current = dummy;
            Node<int> next = current.GetNext();
            int counter = 0;
            //כל עוד יש חוליות אמיתיות
            while (next != null)
            {
                //אם החוליה היא רצף
                if (next.GetValue() == x)
                {
                    counter++;//נוסיף לרצף

                    //נדלג על כל הרצף
                    next = next.GetNext();
                    while (next != null && next.GetValue() == x)
                        next = next.GetNext();
                    //נצא מהלולאה או כשהגענו לסוף
                    //או כשהגענו לחוליה ששונה מהערך
                }
                //אם החוליה אינה ברצף נמשיך בשרשרת
                else
                {
                    current = next;//נמשיך מהנקודה הנוכחית
                    next = current.GetNext();
                }

            }
            return counter;
        }
        #endregion

        #region מיזוג
        public static Node<int> Merge(Node<int> ls1, Node<int>ls2)
        {
            //ראש החוליה הממוזגת הוא הערך של החוליה הראשונה מהשרשרת הראשונה
            Node<int> result = new Node<int>(ls1.GetValue());
            //נעזר בהכנסה לסוף
            Node<int> tail = result;
            //נקדם לחוליה הבאה בשרשרת שכבר טיפלנו
            ls1 = ls1.GetNext();
            //כל עוד יש חוליות באחת מהשרשראות
            while(ls1!=null&&ls2!=null)
            {
                
                tail.SetNext(new Node<int>(ls2.GetValue()));//נטפל בחוליה השניה
                tail =tail.GetNext();//נקדם את הזנב
                tail.SetNext(new Node<int>(ls1.GetValue()));//נכניס מהחוליה הראשונה
                tail = tail.GetNext();//נקדם את הזנב
                //נקדם את הרשימות
                ls1=ls1.GetNext();
                ls2= ls2.GetNext(); 
            }
            //אם נשארו חוליות- נכניס לסוף
            while(ls1!=null)
            {
                tail.SetNext(new Node<int>(ls1.GetValue()));
                tail =tail.GetNext();
                ls1=ls1.GetNext();
            }
            while (ls2 != null)
            {
                tail.SetNext(new Node<int>(ls2.GetValue()));
                tail = tail.GetNext();
                ls2 = ls2.GetNext();
            }
            return result;
        }
        #endregion

    }

}
