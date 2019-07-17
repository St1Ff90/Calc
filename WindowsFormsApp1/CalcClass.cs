using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CalcClass
    {
        public string incomeData;

        public List<string> AnalysString(string str) //переводим строку в коллекцию операций и чисел
        {
            List<string> myList = new List<string>(); //выходная строка
            Stack<string> numbers = new Stack<string>(); //собираем числа из более чем одного символа
            string CurrentTrigonometricFunc = null;
            char[] mathematicaSymbols = new char[] { '+', '-', '/', '*', '(', ')' }; //математические знаки
            char[] trigonometricSymbols = new char[] { 's', 'i', 'n', 'c', 'o', 't', 'g' }; //тригонометрия
            List<string> FuncsNames = new List<string>() { "cos", "sin", "tg", "ctg" };  //проверка на сборку функции
            //дальше передадим cos = €; sin = $; tg = ₴; ctg = £;
            for (int i = 0; i < str.Length; i++)
            {
                bool stopStep = false;

                if (i == 0 && str.ElementAt(i).ToString() == "-") //если выражение начинается с отрицательного числа
                {
                    numbers.Push("-"); //пишем минус в стек числа
                    stopStep = true; //не продолжаем обратотку этого минуса
                }
                
                if ( i > 0 )
                {
                    bool isNum = int.TryParse(str.ElementAt(i-1).ToString(), out int Num); //проверка предыдущего символа на число
                    if (str.ElementAt(i).ToString() == "-" && !isNum) // если не число, значит это минусовое значение
                    {
                        numbers.Push("-");
                        stopStep = true;//не продолжаем обратотку этого минуса
                    }
                }

                if (!stopStep) 
                {                   
                    bool isNum = int.TryParse(str.ElementAt(i).ToString(), out int Num); //проверяем символ на число
                    if (isNum)
                    {
                        numbers.Push(Num.ToString()); //добавляем число в стрек
                    }
                    if (str.ElementAt(i).ToString() == "." || str.ElementAt(i).ToString() == ",")
                    {
                        numbers.Push("."); //добавляем точку в стрек
                    }
                    if (!isNum || i == str.Length - 1) //объединяем значение стека в строку и сохраняем в список
                    {
                        if (numbers.Count != 0) // обрабатываем стек с числами
                        {
                            if (numbers.Peek() != ".") //последней в стеке не может быть точка
                            {
                                Stack<string> stck = new Stack<string>(numbers); //инвертированый стек
                                numbers.Clear();
                                string tempStr = null; //строка с числом

                                while (stck.Count > 0) //переносим стрек с строку
                                {
                                    tempStr += stck.Pop();
                                }
                                myList.Add(tempStr); //добавляем на выход
                            }
                        }
                    }
                    if (trigonometricSymbols.Contains(str.ElementAt(i))) { CurrentTrigonometricFunc += str.ElementAt(i); } //собираем буквы последовательно
                    if (FuncsNames.Contains(CurrentTrigonometricFunc)) //проверяем собранные буквы
                    {
                        switch (CurrentTrigonometricFunc)
                        {
                            case "cos":
                                myList.Add("€");
                                break;
                            case "sin":
                                myList.Add("$");
                                break;
                            case "tg":
                                myList.Add("₴");
                                break;
                            case "ctg":
                                myList.Add("£");
                                break;
                            default:
                                break;
                        }
                        CurrentTrigonometricFunc = null;
                    }
                    if (mathematicaSymbols.Contains(str.ElementAt(i))) { myList.Add(str.ElementAt(i).ToString()); } //проверка на математический символ

                }

                stopStep = false;
            }
return myList; //строка переведена в коллекцию операций
        }

        public int CheckPriority(string str)
        {
            List<string> priority1 = new List<string>() { "+", "-" };
            List<string> priority2 = new List<string>() { "*", "/" };
            List<string> priority3 = new List<string>() { "€", "$", "₴", "£" };
            List<string> priority4 = new List<string>() { "(", ")" };
            if (priority1.Contains(str)) { return 1; }
            if (priority2.Contains(str)) { return 2; }
            if (priority3.Contains(str)) { return 3; }
            if (priority4.Contains(str)) { return 0; }
            else return 0;
        } //определяем приоритет операций

        public Stack<string> MakeReversePolishNotation(List<string> lst)
        {
            Stack<string> outStack = new Stack<string>(); //собираем числа из более чем одного символа
            Stack<string> tempStack = new Stack<string>(); //собираем числа из более чем одного символа
            for (int i = 0; i < lst.Count; i++)
            {
                bool isNum = int.TryParse(lst.ElementAt(i).ToString(), out int Num); //проверяем символ на число
                if (isNum)
                {
                    outStack.Push(Num.ToString());
                } //если число, сразу в стек на выход
                if (!isNum)
                {
                    int priority = CheckPriority(lst.ElementAt(i)); //узнаем приоритет текущего элемента

                    if (tempStack.Count != 0) //проверяем, что временный стек не пуст
                    {
                        if (lst.ElementAt(i) == "(") //скобки сразу передаем в временный стек
                        {
                            tempStack.Push(lst.ElementAt(i));
                        }
                        else if (lst.ElementAt(i) == ")") //если закр. скобка, выводим содержание временного стека на выход
                        {
                            string lastElement = null;
                            do
                            {
                                lastElement = tempStack.Pop();
                                if (lastElement != "(") { outStack.Push(lastElement); } //выбрасываем скобки
                            }
                            while (lastElement != "(");

                        }
                        else
                        {
                            int previousCharPriority = CheckPriority(tempStack.Peek()); //проверяем приоритет предыдущего символа из стека

                            if (priority > previousCharPriority) //если у текущего приоритет выше, добавляем во временный стек
                            {
                                tempStack.Push(lst.ElementAt(i));
                            }
                            else //если = или <, выталкиваем один символ из временного стека в основной а текущий символ помещаем во временный стек. 
                            {
                                outStack.Push(tempStack.Pop());
                                tempStack.Push(lst.ElementAt(i));
                            }
                        }
                    }
                    else //если временный стек пуст, записывем туда операцию
                    {
                        tempStack.Push(lst.ElementAt(i));
                    }
                } //
                if (i == lst.Count - 1)
                {
                    if (tempStack.Count != 0)
                    {
                        do
                        {
                            outStack.Push(tempStack.Pop());
                        }
                        while (tempStack.Count != 0);
                    }
                } //если это последний элемент, выводим временный стек
            }
            return outStack;
        } //формируем братную запись

        public double PostfixNotation(Stack<string> arr)
        {
            string i1 = "2";
            string i2 = "3";
            string i3 = "*";
            return (2 / 3);
        }


        public double MakeCaclulation(string typeOfOperation, int numerator, int divider)
        {
            double resultOfCalcilation;
            resultOfCalcilation = 0.0;
            return resultOfCalcilation;
        }






    }
}
