﻿using System;

namespace _1._1_UmbauGenerics {
    public class MySortedList : MyList {
        /// <summary>
        /// A simple, unoptimized sort algorithm that orders list elements from lowest to highest.
        /// </summary>
        public void BubbleSort() {
            if (null == head || null == head.Next) {
                return;
            }

            bool swapped;
            do {
                Node previous = null;
                Node curr = head;
                swapped = false;
                while (curr.next != null) {
                    IComparable comp = curr.Data as IComparable;
                    if (comp == null) {
                        throw new Exception("data-object must implement ICOmparable");
                    }

                    if (comp.CompareTo(curr.next.Data) > 0) {
                        Node tmp = curr.next;
                        curr.next = curr.next.next;
                        tmp.next = curr;

                        if (previous == null) {
                            head = tmp;
                        } else {
                            previous.next = tmp;
                        }

                        previous = tmp;
                        swapped = true;
                    } else {
                        previous = curr;
                        curr = curr.next;
                    }
                } // end while
            } while (swapped);
        }
    }
}