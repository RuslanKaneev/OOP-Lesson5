

var n1 = new RationalNumber(1, 5);
var n2 = new RationalNumber(2, 3);
var n3 = n1 * n2;
Console.WriteLine($"Умножение: Числитель:{ n3.Numerator},Знаменатель: {n3.Denominator}");

n3 = n1 / n2;
Console.WriteLine($"Деление: Числитель: {n3.Numerator},Знаменатель: {n3.Denominator}");

n3 = n1 + n2;
Console.WriteLine($"Сложение: Числитель: {n3.Numerator},Знаменатель: {n3.Denominator}");
var nc = new RationalNumber(1, 10);

n3 = nc + 3;
Console.WriteLine($"Сложение с числом: Числитель: {n3.Numerator},Знаменатель: {n3.Denominator}");

var n4 = new RationalNumber(1, 5);
var n5 = new RationalNumber(1, 0);
n3 = n4 - n5;
Console.WriteLine($"Вычитание: Числитель: {n3.Numerator},Знаменатель: {n3.Denominator}");
n3 = nc - 1;
Console.WriteLine($"Вычитание числа: Числитель: {n3.Numerator},Знаменатель: {n3.Denominator}");
n3 = 1 - nc;
Console.WriteLine($"Вычитание из числа: Числитель: {n3.Numerator},Знаменатель: {n3.Denominator}");

n3 = n1 % n2;
Console.WriteLine($"Остаток от деления: Числитель: {n3.Numerator},Знаменатель: {n3.Denominator}");

var sr = n1 > n2;
Console.WriteLine($"Больше: {sr}");

sr = n1 < n2;
Console.WriteLine($"Меньше: {sr}");

sr = n1 <= n2;
Console.WriteLine($"Меньше или равно: {sr}");

sr = n1 >= n2;
Console.WriteLine($"Больше или равно: {sr}");

sr = n1 == n2;
Console.WriteLine($"Равны числа: {sr}");

sr = n1 != n2;
Console.WriteLine($"Не равно: {sr}");






/*Создать класс рациональных чисел. В классе два поля – числитель и
знаменатель. Предусмотреть конструктор. Определить операторы ==, != (метод
Equals()), <, >, <=, >=, +, – , ++, --. Переопределить метод ToString() для вывода
дроби. Определить операторы преобразования типов между типом дробь, float, int.
Определить операторы *, /, %.
*/


class RationalNumber
{
    private int _numerator;
    public int Numerator
    {
        get { return _numerator; }
        set { _numerator = value; }
    }


    private int _denominator;
    public int Denominator
    {
        get { return _denominator; }
        set
        {
            if (value == 0)
            {
                _numerator = 0;
                _denominator = 1;
            }

            else
                _denominator = value;

        }
    }


    public RationalNumber(int x, int y)
    {
        Numerator = x;
        Denominator = y;
    }

    //  оператор вычитания
    public static RationalNumber operator -(RationalNumber operand1, RationalNumber operand2)
    {
        int smallMultiplier = SmallCommonMultiple(operand1.Denominator, operand2.Denominator);
        // множитель к первой дроби
        int firstMultiplier = smallMultiplier / operand1.Denominator;
        // множитель ко второй дроби
        int secondMultiplier = smallMultiplier / operand2.Denominator;

        operand1.Numerator = firstMultiplier * operand1.Numerator;
        operand1.Denominator = firstMultiplier * operand1.Denominator;
        operand2.Numerator = secondMultiplier * operand2.Numerator;


        return new RationalNumber(operand1.Numerator - operand2.Numerator, operand1.Denominator);

    }
    //  оператор сложения
    public static RationalNumber operator +(RationalNumber operand1, RationalNumber operand2)
    {
        int smallMultiplier = SmallCommonMultiple(operand1.Denominator, operand2.Denominator);
        // множитель к первой дроби
        int firstMultiplier = smallMultiplier / operand1.Denominator;
        // множитель ко второй дроби
        int secondMultiplier = smallMultiplier / operand2.Denominator;

        operand1.Numerator = firstMultiplier * operand1.Numerator;
        operand1.Denominator = firstMultiplier * operand1.Denominator;
        operand2.Numerator = secondMultiplier * operand2.Numerator;


        return new RationalNumber(operand1.Numerator + operand2.Numerator, operand1.Denominator);

    }
    //сложение с целым числом
    public static RationalNumber operator +(RationalNumber operand12, int number)
    {   //привожу к одному знаменателю
        number = number * operand12.Denominator;
        return new RationalNumber(operand12.Numerator + number, operand12.Denominator);

    }

    //вычитание с целым числом
    public static RationalNumber operator -(RationalNumber operand1, int number)
    {   //привожу к одному знаменателю
        number *= operand1.Denominator;
        return new RationalNumber(operand1.Numerator - number, operand1.Denominator);

    }

    //вычитание из целого числа
    public static RationalNumber operator -(int number, RationalNumber operand1)
    {   //привожу к одному знаменателю
        number *= operand1.Denominator;
        return new RationalNumber(number - operand1.Numerator, operand1.Denominator);

    }
    //наибольший общий делитель
    private static int LowCommonDenominator(int denominator1, int denominator2)
    {

        while (denominator2 != 0)
        {
            int temp = denominator2;
            denominator2 = denominator1 % denominator2;
            denominator1 = temp;

        }
        return denominator1;

    }
    // наименьшее общее кратное
    private static int SmallCommonMultiple(int denominator1, int denominator2)
    {



        return denominator1 * denominator2 / LowCommonDenominator(denominator1, denominator2);


    }


    //  оператор  умножение

    public static RationalNumber operator *(RationalNumber operand1, RationalNumber operand2)
    {

        return new RationalNumber(operand1.Numerator * operand2.Numerator, operand1.Denominator * operand2.Denominator);

    }
    //  оператор  деления

    public static RationalNumber operator /(RationalNumber operand1, RationalNumber operand2)
    {

        return new RationalNumber(operand1.Numerator * operand2.Denominator, operand1.Denominator * operand2.Numerator);

    }
    //мостаток от деления
    public static RationalNumber operator %(RationalNumber operand1, RationalNumber operand2)
    {
        var smallMultiplier = SmallCommonMultiple(operand1.Denominator, operand2.Denominator);
        // множитель к первой дроби
        var firstMultiplier = smallMultiplier / operand1.Denominator;
        // множитель ко второй дроби
        var secondMultiplier = smallMultiplier / operand2.Denominator;

        var n1 = firstMultiplier * operand1.Numerator;
        var n2 = secondMultiplier * operand2.Numerator;
        var d = firstMultiplier * operand1.Denominator;
        if (n1 < n2)
            return new RationalNumber(operand1.Numerator, operand1.Denominator);

        else if (n2 == n1)
            return new RationalNumber(0, 1);
        else
        {
            int inTN = (operand1.Numerator * operand2.Denominator) / (operand2.Denominator * operand2.Numerator);
            return new RationalNumber(n1 - inTN * n2, d);
        }

    }
    //  оператор  сравнения больше
    public static bool operator >(RationalNumber operand1, RationalNumber operand2)
    {
        int smallMultiplier = SmallCommonMultiple(operand1.Denominator, operand2.Denominator);
        // множитель к первой дроби
        int firstMultiplier = smallMultiplier / operand1.Denominator;
        // множитель ко второй дроби
        int secondMultiplier = smallMultiplier / operand2.Denominator;

        operand1.Numerator = firstMultiplier * operand1.Numerator;
        operand2.Numerator = secondMultiplier * operand2.Numerator;

        if (operand1.Numerator > operand2.Numerator)
            return true;
        else
            return false;
    }

    //  оператор  сравнения меньше
    public static bool operator <(RationalNumber operand1, RationalNumber operand2)
    {
        int smallMultiplier = SmallCommonMultiple(operand1.Denominator, operand2.Denominator);
        // множитель к первой дроби
        int firstMultiplier = smallMultiplier / operand1.Denominator;
        // множитель ко второй дроби
        int secondMultiplier = smallMultiplier / operand2.Denominator;

        operand1.Numerator = firstMultiplier * operand1.Numerator;
        operand2.Numerator = secondMultiplier * operand2.Numerator;

        if (operand1.Numerator < operand2.Numerator)
            return true;
        else
            return false;
    }

    //сравнение с целыми числами 
    public static bool operator >(RationalNumber operand1, int number)
    {   //привожу к одному знаменателю
        number *= operand1.Denominator;
        if (operand1.Numerator > number)
            return true;
        else
            return false;
    }


    public static bool operator <(RationalNumber operand1, int number)
    {   //привожу к одному знаменателю
        number *= operand1.Denominator;
        if (operand1.Numerator < number)
            return true;
        else
            return false;
    }

    //  оператор  сравнения больше или равно
    public static bool operator >=(RationalNumber operand1, RationalNumber operand2)
    {
        int smallMultiplier = SmallCommonMultiple(operand1.Denominator, operand2.Denominator);
        // множитель к первой дроби
        int firstMultiplier = smallMultiplier / operand1.Denominator;
        // множитель ко второй дроби
        int secondMultiplier = smallMultiplier / operand2.Denominator;

        operand1.Numerator = firstMultiplier * operand1.Numerator;
        operand2.Numerator = secondMultiplier * operand2.Numerator;

        if (operand1.Numerator >= operand2.Numerator)
            return true;
        else
            return false;
    }
    //  оператор  сравнения меньше или равно
    public static bool operator <=(RationalNumber operand1, RationalNumber operand2)
    {
        int smallMultiplier = SmallCommonMultiple(operand1.Denominator, operand2.Denominator);
        // множитель к первой дроби
        int firstMultiplier = smallMultiplier / operand1.Denominator;
        // множитель ко второй дроби
        int secondMultiplier = smallMultiplier / operand2.Denominator;

        operand1.Numerator = firstMultiplier * operand1.Numerator;
        operand2.Numerator = secondMultiplier * operand2.Numerator;

        if (operand1.Numerator <= operand2.Numerator)
            return true;
        else
            return false;
    }

    //сравнение с целыми числами 
    public static bool operator <=(RationalNumber operand1, int number)
    {   //привожу к одному знаменателю
        number *= operand1.Denominator;
        if (operand1.Numerator <= number)
            return true;
        else
            return false;
    }

    //сравнение с целыми числами 
    public static bool operator >=(RationalNumber operand1, int number)
    {   //привожу к одному знаменателю
        number *= operand1.Denominator;
        if (operand1.Numerator >= number)
            return true;
        else
            return false;
    }

    //
    public static RationalNumber operator ++(RationalNumber operand1)
    {
        return new RationalNumber(operand1.Numerator += operand1.Denominator, operand1.Denominator);

    }
    public static RationalNumber operator --(RationalNumber operand1)
    {
        return new RationalNumber(operand1.Numerator -= operand1.Denominator, operand1.Denominator);

    }

    public static bool operator ==(RationalNumber operand1, RationalNumber operand2)
    {
        int smallMultiplier = SmallCommonMultiple(operand1.Denominator, operand2.Denominator);
        // множитель к первой дроби
        int firstMultiplier = smallMultiplier / operand1.Denominator;
        // множитель ко второй дроби
        int secondMultiplier = smallMultiplier / operand2.Denominator;

       
        operand1.Numerator = firstMultiplier * operand1.Numerator;
        operand2.Numerator = secondMultiplier * operand2.Numerator;

        if ((operand1.Numerator == operand2.Numerator) && (operand1.Denominator == operand2.Denominator))
            return true;
        else
            return false;
    }

    public static bool operator !=(RationalNumber operand1, RationalNumber operand2)
    {
        int smallMultiplier = SmallCommonMultiple(operand1.Denominator, operand2.Denominator);
        // множитель к первой дроби
        int firstMultiplier = smallMultiplier / operand1.Denominator;
        // множитель ко второй дроби
        int secondMultiplier = smallMultiplier / operand2.Denominator;

        operand1.Numerator = firstMultiplier * operand1.Numerator;
        operand2.Numerator = secondMultiplier * operand2.Numerator;

        if ((operand1.Numerator == operand2.Numerator) && (operand1.Denominator == operand2.Denominator))
            return false;
        else
            return true;
    }

    public static bool operator ==(RationalNumber operand1, int number)
    {   //привожу к одному знаменателю
        number *= operand1.Denominator;
        if (operand1.Numerator == number)
            return true;
        else
            return false;
    }

    //сравнение с целыми числами 
    public static bool operator !=(RationalNumber operand1, int number)
    {   //привожу к одному знаменателю
        number *= operand1.Denominator;
        if (operand1.Numerator != number)
            return true;
        else
            return false;
    }

    public static implicit operator float(RationalNumber operator1)
    {

        return (float)operator1.Numerator / (float)operator1.Denominator;
    }

    public static implicit operator int(RationalNumber operator1)
    {
        return operator1.Numerator / operator1.Denominator;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}