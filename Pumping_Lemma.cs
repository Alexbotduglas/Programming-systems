using System;
using System.Collections;
using System.Collections.Generic;
namespace kp_1
{
    class XYiZViK//структура, в которой находится оптимально разбитая цепочка XYZVK
    {
        public XYiZViK(string W, string Y, string V, int i, int p)//конструктор принимает исходную цепочку, повторяющуюся подцепочку, кол-во его повторений и позицию первого символа
        {
            this.Y = Y;
            this.i = i;
            X = W.Substring(0, p);
            Z = W.Substring(p + (Y.Length * i), W.Length - (p + (Y.Length * i)));

        }
        public string Y;
        public string X;
        public string Z;
        public string K;
        public string V;
        public int i;
    }

    class PumpingLema
    {
        public PumpingLema(String W)
        {
            this.W = W;
            this.WereChecked = new List<string>();
            this.ResultW = new List<XYiZViK>();
            this.FindY();
            this.FindV();
        }
        private string W; //исходная цепочка
        private List<XYiZViK> ResultW; // список оптимальных разбиений цепочки на X, Y^i, Z, V^i, K
        private List<string> WereChecked; //список проверенных в качстве Y подцепочек
        private void FindYi(string Y)	// Поиск масиимальной степени предпологаемого Y
        private void FindVi(string V)   // Поиск масиимальной степени предпологаемого V
        {
            if (WereChecked.BinarySearch(Y) >= 0) return; //если Y был проверен ранее, повторной проверки не будет
            WereChecked.Add(Y);//добавляем рассмотренную Y в список рассмотреных
            WereChecked.Sort();
            for (int j = 0; j < Y.Length; j++)//нач. поз. провероки повтора подстроки
            {
                int P = 0; //Начальная позиция самого длинного найденого повторения Y
                int CurrenP = 0; //Начальая позиция рассматриваемой последовательности из Y 
                int i = 0; // Количество Y самого длинного найденого повторения Y
                int Curreni = 0; //Количество Y в рассматриваемой последовательности Y
                Stack<XYiZViK> S = new Stack<XYiZViK>(); // Стек оптимальных разбиений при предпологаемом Y
                for (int p = j; p <= this.W.Length; p += Y.Length)//Последователное "прикладывание" Y друг за другом, поиск самой длинной последовательности
                {
                    if (!(p > W.Length - Y.Length) && string.Compare(Y, W.Substring(p, Y.Length), StringComparison.Ordinal) == 0)// совпадение
                    {
                        if (Curreni == 0) CurrenP = p; //если до этого Y не встречалась, запоминаем позицию начала
                        Curreni++; //Увеличиваем количество Y в рассматриваемой последовательности Y
                    }
                    else
                    {
                        if (Curreni >= i) //Если нашли больше Y подряд, чем до этого
                        {
                            if (Curreni > i) S.Clear(); //Очищаем предидущие результаты, так как новый лучше
                            i = Curreni; //Текущее количество - максимально
                            P = CurrenP; //Текущая позиция соответствует Начальной позиции максимального повторяия Y
                            S.Push(new XYiZViK(this.W, Y, i, P));//Добовляем в стек новое разбиение
                        }
                        Curreni = 0; //обнулям текущий счетчик повторений Y
                    }
                }
                // Begin Vasya---------------------------------
                if (WereChecked.BinarySearch(V) >= 0) return; //если V был проверен ранее, повторной проверки не будет
                WereChecked.Add(V);//добавляем рассмотренную V в список рассмотреных
                WereChecked.Sort();
                for (int j = 0; j < V.Length; j++)//нач. поз. провероки повтора подстроки
                {
                    int P = 0; //Начальная позиция самого длинного найденого повторения V
                    int CurrenP = 0; //Начальая позиция рассматриваемой последовательности из V 
                    int i = 0; // Количество V самого длинного найденого повторения V
                    int Curreni = 0; //Количество V в рассматриваемой последовательности V
                    Stack<XYiZViK> S = new Stack<XYiZViK>(); // Стек оптимальных разбиений при предпологаемом V
                    for (int p = j; p <= this.W.Length; p += V.Length)//Последователное "прикладывание" V друг за другом, поиск самой длинной последовательности
                    {
                        if (!(p > W.Length - V.Length) && string.Compare(V, W.Substring(p, V.Length), StringComparison.Ordinal) == 0)// совпадение
                        {
                            if (Curreni == 0) CurrenP = p; //если до этого V не встречалась, запоминаем позицию начала
                            Curreni++; //Увеличиваем количество V в рассматриваемой последовательности V
                        }
                        else
                        {
                            if (Curreni >= i) //Если нашли больше V подряд, чем до этого
                            {
                                if (Curreni > i) S.Clear(); //Очищаем предидущие результаты, так как новый лучше
                                i = Curreni; //Текущее количество - максимально
                                P = CurrenP; //Текущая позиция соответствует Начальной позиции максимального повторяия Y
                                S.Push(new XYiZViK(this.W, V, i, P));//Добовляем в стек новое разбиение
                            }
                            Curreni = 0; //обнулям текущий счетчик повторений V
                        }
                    }
                    // Fin Vasya---------------------------
                    if (i > 1 && (this.ResultW.Count == 0 || this.ResultW[0].i <= i)) //Если нашлись последовательности Y и найденые разбиения лучше предидущих или первые
                    {
                        if (this.ResultW.Count != 0 && this.ResultW[0].i < i) this.ResultW.Clear(); //очищаем предидущие разбиения
                        XYiZ Result;
                        while (S.TryPop(out Result)) this.ResultW.Add(Result);//добавляем все новые разбиения из стека в общий список разбиений
                    }
                }
            }
        }
        private void FindY()// Поиск максимальных повторений для всех вощможных Y из W
        {
            for (int LengthY = 1; LengthY <= W.Length / 2; LengthY++) // Перебираем Y начиная с длинны 1, Y длинны больше половины W будет повторяться всегда 1 раз, нет смысла проверять
            {
                for (int p = 0; p < W.Length - LengthY; ++p) //Выбираем начало Y выбранной длинны с каждой возможной позиции в W
                {
                    this.FindYi(W.Substring(p, LengthY)); //Поиск масиимальной степени предпологаемого Y
                }
            }
        }
        private void FindV()// Поиск максимальных повторений для всех вощможных V из W
        {
            for (int LengthV = 1; LengthV <= W.Length / 2; LengthV++) // Перебираем V начиная с длинны 1, V длинны больше половины W будет повторяться всегда 1 раз, нет смысла проверять
            {
                for (int p = 0; p < W.Length - LengthV; ++p) //Выбираем начало V выбранной длинны с каждой возможной позиции в W
                {
                    this.FindVi(W.Substring(p, LengthV)); //Поиск масиимальной степени предпологаемого V
                }
            }
        }
        public void PrintResult()//вывод оптимальных разбиений на консоль
        {
            foreach (XYiZViK S in this.ResultW)
            {
                Console.WriteLine(S.X + " " + S.Y + "^" + S.i + " " + S.Z + " " + S.V + "^" + S.i + " " + S.K + " ");
            }
        }
    }

    class PumpingLemaDebug
    {
        public PumpingLemaDebug(String W)
        {
            this.W = W;
            this.WereChecked = new List<string>();
            this.ResultW = new List<XYiZViK>();
            Console.WriteLine("Введена строка:" + this.W);
            this.FindY();
        }
        public bool BestResult;
        private string W; //исходная цепочка
        private List<XYiZViK> ResultW; // список оптимальных разбиений цепочки на X, Y^i, Z
        private List<string> WereChecked; //список проверенных в качстве Y подцепочек
        private void FindYi(string Y) // Поиск масиимальной степени предпологаемого Y
        {
            if (WereChecked.BinarySearch(Y) >= 0)
            {
                Console.WriteLine(Y + " была проверена ранее");
                return; //если Y был проверен ранее, повторной проверки не будет
            }
            WereChecked.Add(Y);//добавляем рассмотренную Y в список рассмотреных
            WereChecked.Sort();
            for (int j = 0; j < Y.Length; j++)//нач. поз. провероки повтора подстроки
            {
                int P = 0; //Начальная позиция самого длинного найденого повторения Y
                int CurrenP = 0; //Начальая позиция рассматриваемой последовательности из Y 
                int i = 0; // Количество Y самого длинного найденого повторения Y
                int Curreni = 0; //Количество Y в рассматриваемой последовательности Y
                Stack<XYiZViK> S = new Stack<XYiZViK>(); // Стек оптимальных разбиений при предпологаемом Y
                for (int p = j; p <= this.W.Length; p += Y.Length)//Последователное "прикладывание" Y друг за другом, поиск самой длинной последовательности
                {
                    if (!(p > W.Length - Y.Length) && string.Compare(Y, W.Substring(p, Y.Length), StringComparison.Ordinal) == 0)// совпадение
                    {
                        if (Curreni == 0) CurrenP = p; //если до этого Y не встречалась, запоминаем позицию начала
                        Curreni++; //Увеличиваем количество Y в рассматриваемой последовательности Y
                        Console.WriteLine("Y встретился подряд " + Curreni + " раз");
                    }
                    else
                    {
                        if (Curreni >= i) //Если нашли больше Y подряд, чем до этого
                        {
                            Console.WriteLine("Y встретился не менее раз подрят, чем ранее");
                            if (Curreni > i)
                            {
                                Console.WriteLine("Y встретился больше раз, чем ранее, очищаю старый результат");
                                S.Clear(); //Очищаем предидущие результаты, так как новый лучше
                            }
                            i = Curreni; //Текущее количество - максимально
                            P = CurrenP; //Текущая позиция соответствует Начальной позиции максимального повторяия Y
                            S.Push(new XYiZViK(this.W, Y, i, P));//Добовляем в стек новое разбиение
                            Console.WriteLine("Добавляю результат в стек");
                        }
                        Curreni = 0; //обнулям текущий счетчик повторений Y
                    }
                }
                if (i > 1 && (this.ResultW.Count == 0 || this.ResultW[0].i <= i)) //Если нашлись последовательности Y и найденые разбиения лучше предидущих или первые
                {
                    if (this.ResultW.Count != 0 && this.ResultW[0].i < i)
                    {
                        Console.WriteLine("Новый результат лучше старого, удаляю старый");
                        this.ResultW.Clear(); //очищаем предидущие разбиения
                    }
                    XYiZ Result;
                    while (S.TryPop(out Result)) this.ResultW.Add(Result);//добавляем все новые разбиения из стека в общий список разбиений
                    Console.WriteLine("Добавлен новый результат, теперь список лучших разбиений:");
                    this.PrintResult();
                    if ((ResultW[0].i) * ResultW[0].Y.Length == W.Length)
                    {
                        this.BestResult = true;
                        Console.WriteLine("Найдено лучшее решение");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Старый результат лучше, не добавляю");
                }
            }
        }
        private void FindY()// Поиск максимальных повторений для всех вощможных Y из W
        {
            Console.WriteLine("Начало перебора подцепочек, принимаемых как Y");
            for (int LengthY = 1; LengthY <= W.Length / 2 && !this.BestResult; LengthY++) // Перебираем Y начиная с длинны 1, Y длинны больше половины W будет повторяться всегда 1 раз, нет смысла проверять
            {
                Console.WriteLine("длинна Y:" + LengthY);
                for (int p = 0; p < W.Length - LengthY && !this.BestResult; ++p) //Выбираем начало Y выбранной длинны с каждой возможной позиции в W
                {
                    Console.WriteLine("значение Y:" + W.Substring(p, LengthY));
                    this.FindYi(W.Substring(p, LengthY)); //Поиск масиимальной степени предпологаемого Y
                }
            }
        }

        ////////////////------------------
        class PumpingLemmaDebug
        {
            public PumpingLemmaDebug(String W)
            {
                this.W = W;
                this.WereChecked = new List<string>();
                this.ResultW = new List<XYiZViK>();
                Console.WriteLine("Введена строка:" + this.W);
                this.FindV();
            }
            public bool BestResult;
            private string W; //исходная цепочка
            private List<XYiZViK> ResultW; // список оптимальных разбиений цепочки на X, Y^i, Z, V^i, K
            private List<string> WereChecked; //список проверенных в качстве Y подцепочек
            private void FindVi(string V) // Поиск масиимальной степени предпологаемого Y
            {
                if (WereChecked.BinarySearch(V) >= 0)
                {
                    Console.WriteLine(V + " была проверена ранее");
                    return; //если V был проверен ранее, повторной проверки не будет
                }
                WereChecked.Add(V);//добавляем рассмотренную Y в список рассмотреных
                WereChecked.Sort();
                for (int j = 0; j < V.Length; j++)//нач. поз. провероки повтора подстроки
                {
                    int P = 0; //Начальная позиция самого длинного найденого повторения Y
                    int CurrenP = 0; //Начальая позиция рассматриваемой последовательности из Y 
                    int i = 0; // Количество Y самого длинного найденого повторения Y
                    int Curreni = 0; //Количество Y в рассматриваемой последовательности Y
                    Stack<XYiZViK> S = new Stack<XYiZViK>(); // Стек оптимальных разбиений при предпологаемом Y
                    for (int p = j; p <= this.W.Length; p += V.Length)//Последователное "прикладывание" Y друг за другом, поиск самой длинной последовательности
                    {
                        if (!(p > W.Length - V.Length) && string.Compare(V, W.Substring(p, V.Length), StringComparison.Ordinal) == 0)// совпадение
                        {
                            if (Curreni == 0) CurrenP = p; //если до этого V не встречалась, запоминаем позицию начала
                            Curreni++; //Увеличиваем количество V в рассматриваемой последовательности Y
                            Console.WriteLine("V встретился подряд " + Curreni + " раз");
                        }
                        else
                        {
                            if (Curreni >= i) //Если нашли больше Y подряд, чем до этого
                            {
                                Console.WriteLine("V встретился не менее раз подрят, чем ранее");
                                if (Curreni > i)
                                {
                                    Console.WriteLine("V встретился больше раз, чем ранее, очищаю старый результат");
                                    S.Clear(); //Очищаем предидущие результаты, так как новый лучше
                                }
                                i = Curreni; //Текущее количество - максимально
                                P = CurrenP; //Текущая позиция соответствует Начальной позиции максимального повторяия V
                                S.Push(new XYiZViK(this.W, V, i, P));//Добовляем в стек новое разбиение
                                Console.WriteLine("Добавляю результат в стек");
                            }
                            Curreni = 0; //обнулям текущий счетчик повторений V
                        }
                    }
                    if (i > 1 && (this.ResultW.Count == 0 || this.ResultW[0].i <= i)) //Если нашлись последовательности Y и найденые разбиения лучше предидущих или первые
                    {
                        if (this.ResultW.Count != 0 && this.ResultW[0].i < i)
                        {
                            Console.WriteLine("Новый результат лучше старого, удаляю старый");
                            this.ResultW.Clear(); //очищаем предидущие разбиения
                        }
                        XYiZViK Result;
                        while (S.TryPop(out Result)) this.ResultW.Add(Result);//добавляем все новые разбиения из стека в общий список разбиений
                        Console.WriteLine("Добавлен новый результат, теперь список лучших разбиений:");
                        this.PrintResult();
                        if ((ResultW[0].i) * ResultW[0].Y.Length == W.Length)
                        {
                            this.BestResult = true;
                            Console.WriteLine("Найдено лучшее решение");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Старый результат лучше, не добавляю");
                    }
                }
            }

            private void FindV()// Поиск максимальных повторений для всех вощможных V из W
            {
                Console.WriteLine("Начало перебора подцепочек, принимаемых как Y");
                for (int LengthV = 1; LengthV <= W.Length / 2 && !this.BestResult; LengthV++) // Перебираем V начиная с длинны 1, V длинны больше половины W будет повторяться всегда 1 раз, нет смысла проверять
                {
                    Console.WriteLine("длинна V:" + LengthV);
                    for (int p = 0; p < W.Length - LengthV && !this.BestResult; ++p) //Выбираем начало V выбранной длинны с каждой возможной позиции в W
                    {
                        Console.WriteLine("значение V:" + W.Substring(p, LengthV));
                        this.FindVi(W.Substring(p, LengthV)); //Поиск масиимальной степени предпологаемого V
                    }
                }
            }
            ///////////////////--------------------
            public void PrintResult()//вывод оптимальных разбиений на консоль
            {
                foreach (XYiZViK S in this.ResultW)
                {
                    Console.WriteLine(S.X + " " + S.Y + "^" + S.i + " " + S.Z + " " + S.V + "^" + S.i + " " + S.K + " ");
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {
                    PumpingLema W = new PumpingLema(Console.ReadLine());//Проверяем лему о накачке для введенной цепочки 
                    W.PrintResult();//вывод оптимальных разбиений на консоль
                }
            }
        }
    }
}
