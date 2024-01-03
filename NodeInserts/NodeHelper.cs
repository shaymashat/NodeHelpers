using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public static Node<char> Reverse(Node<char> text)
        {

            throw new NotImplementedException();
           
           
        }

        public static Node<char> ReverseWithDummy(Node<char>text)
        {


            throw new NotImplementedException();
        }




        public static bool IsEqual<X>(Node<X> ls1, Node<X>ls2)
        {
           throw new NotImplementedException("To do");               

        }

        #endregion
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
        public static char Pitamar(Node<int> list)
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
    }

}
