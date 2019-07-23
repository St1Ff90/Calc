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
            //дальше передадим cos = cos; sin = sin; tg = tg; ctg = ctg;
            for (int i = 0; i < str.Length; i++)
            {
                bool stopStep = false;

                if (i == 0 && str[i].ToString() == "-") //если выражение начинается с отрицательного числа
                {
                    numbers.Push("-"); //пишем минус в стек числа
                    stopStep = true; //не продолжаем обратотку этого минуса
                }

                if (i > 0)
                {
                    //bool iiii = str[i] > 47 && str[i] < 58;
                    bool isNum = str[i - 1] > 47 && str[i - 1] < 58; //проверка предыдущего символа на число
                    if (str[i].ToString() == "-" && !isNum) // если не число, значит это минусовое значение
                    {
                        numbers.Push("-");
                        stopStep = true;//не продолжаем обратотку этого минуса
                    }
                }

                if (!stopStep)
                {
                    bool isNum = str[i] > 47 && str[i] < 58; //проверяем символ на число
                    if (isNum)
                    {
                        numbers.Push(str[i].ToString()); //добавляем число в стрек
                    }
                    if (str[i].ToString() == "." || str[i].ToString() == ",")
                    {
                        numbers.Push(","); //добавляем точку в стрек
                    }
                    if (!isNum || i == str.Length - 1) //объединяем значение стека в строку и сохраняем в список
                    {
                        if (numbers.Count != 0) // обрабатываем стек с числами
                        {
                            if (numbers.Peek() != ",") //последней в стеке не может быть точка
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
                    if (trigonometricSymbols.Contains(str[i])) { CurrentTrigonometricFunc += str[i]; } //собираем буквы последовательно
                    if (FuncsNames.Contains(CurrentTrigonometricFunc)) //проверяем собранные буквы
                    {
                        switch (CurrentTrigonometricFunc)
                        {
                            case "cos":
                                myList.Add("cos");
                                break;
                            case "sin":
                                myList.Add("sin");
                                break;
                            case "tg":
                                myList.Add("tg");
                                break;
                            case "ctg":
                                myList.Add("ctg");
                                break;
                            default:
                                break;
                        }
                        CurrentTrigonometricFunc = null;
                    }
                    if (mathematicaSymbols.Contains(str[i])) { myList.Add(str[i].ToString()); } //проверка на математический символ

                }

                stopStep = false;
            }
            return myList; //строка переведена в коллекцию операций
        }

        public int CheckPriority(string str)
        {
            List<string> priority1 = new List<string>() { "+", "-" };
            List<string> priority2 = new List<string>() { "*", "/" };
            List<string> priority3 = new List<string>() { "cos", "sin", "tg", "ctg" };
            List<string> priority4 = new List<string>() { "(", ")" };
            if (priority1.Contains(str)) { return 1; }
            if (priority2.Contains(str)) { return 2; }
            if (priority3.Contains(str)) { return 3; }
            if (priority4.Contains(str)) { return 0; }
            else return 0;
        } //определяем приоритет операций

        public Stack<string> MakeReversePolishNotation(List<string> lst)
        {
            Stack<string> outStack = new Stack<string>(); //стек на выход
            Stack<string> tempStack = new Stack<string>(); //стек для обработки
            for (int i = 0; i < lst.Count; i++)
            {
                bool isDNum = Double.TryParse(lst[i].ToString(), out double DNum);//проверяем символ на число
                if (isDNum)
                {
                    outStack.Push(DNum.ToString());
                } //если число, сразу в стек на выход
                if (!isDNum)
                {
                    int priority = CheckPriority(lst[i]); //узнаем приоритет текущего элемента

                    if (tempStack.Count != 0) //проверяем, что временный стек не пуст
                    {
                        if (lst[i] == "(") //скобки сразу передаем в временный стек
                        {
                            tempStack.Push(lst[i]);
                        }
                        else if (lst[i] == ")") //если закр. скобка, выводим содержание временного стека на выход
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
                                tempStack.Push(lst[i]);
                            }
                            else //если = или <, выталкиваем один символ из временного стека в основной а текущий символ помещаем во временный стек. 
                            {
                                outStack.Push(tempStack.Pop());
                                tempStack.Push(lst[i]);
                            }
                        }
                    }
                    else //если временный стек пуст, записывем туда операцию
                    {
                        tempStack.Push(lst[i]);
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

        public double PostfixNotation(Stack<string> stk) //просчет обратной записи
        {
            Stack<string> tempStack = new Stack<string>();
            Stack<string> mainStack = new Stack<string>(stk); // инсертированные входной стек
            string[] mathematicaSymbols = new string[] { "+", "-", "/", "*" }; //математические знаки

            do
            {
                string tempStr = mainStack.Pop(); //анализируем элемент стека
                bool isDNum = Double.TryParse(tempStr, out double DNum);//проверяем символ на число
                if (isDNum)
                {
                    tempStack.Push(tempStr); //запихиваем во временный стек
                }
                if (!isDNum) //если операция
                {
                    double result = 0;
                    if (mathematicaSymbols.Contains(tempStr)) //если математическая операция (2 операнда)
                    {
                        double secondNum = Double.Parse(tempStack.Pop());
                        double fierstNum = Double.Parse(tempStack.Pop());

                        switch (tempStr)
                        {
                            case "+":
                                result = fierstNum + secondNum;
                                break;
                            case "-":
                                result = fierstNum - secondNum;
                                break;
                            case "*":
                                result = fierstNum * secondNum;
                                break;
                            case "/":
                                result = fierstNum / secondNum;
                                break;
                            default:
                                break;
                        }
                        tempStack.Push(result.ToString());
                    }
                    else //если триготометрия (1 операнд)
                    {
                        double fierstNum = Double.Parse(tempStack.Pop());
                        switch (tempStr)
                        {
                            case "cos":
                                result = Math.Cos(fierstNum);
                                break;
                            case "sin":
                                result = Math.Sin(fierstNum);
                                break;
                            case "tg":
                                result = Math.Tan(fierstNum);
                                break;
                            case "ctg":
                                result = 1.0 / Math.Tan(fierstNum);
                                break;
                            default:
                                break;
                        }
                        tempStack.Push(result.ToString());
                    }
                }
            }
            while (mainStack.Count != 0);

            return (Math.Round(Double.Parse(tempStack.Pop()), 2)); //результат расчетов
        }

    }
}
