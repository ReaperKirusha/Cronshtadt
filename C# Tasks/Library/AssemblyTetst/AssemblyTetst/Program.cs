using System;
using System.Reflection;

namespace AssemblyTetst
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFrom("LibraryTest.dll");

            //который запускается перед остальными тестами
            MethodInfo StartMethod = null;

            //метод через который запускаются методы с атрибутом Test
            MethodInfo TestMethod;

            // Ищем классы
            foreach (Type TestType in assembly.GetTypes())
            {
                // Ищем классы, которые имеют атрибут TestFixture
                if (TestType.IsDefined(typeof(NUnit.Framework.TestFixtureAttribute), false))
                {
                    //создаем экземпляр такого класса
                    object obj = Activator.CreateInstance(TestType);

                    // Ищем метод, который имеет атрибут SetUp, когда находим
                    // приcваиваем StartMethod это значение
                    // И дальше начинается цикл на запуск методов с атрибутом Test
                    foreach (MethodInfo mi in TestType.GetMethods())
                    {
                        if (mi.IsDefined(typeof(NUnit.Framework.SetUpAttribute), false))
                        {                            
                            StartMethod = TestType.GetMethod(mi.Name.ToString());
                            break;
                        }
                    }
                    // Ищем методы этого класса

                    foreach (MethodInfo mi in TestType.GetMethods())
                    {
                        // Ищем методы, которые имеют атрибут Test                       
                        if (mi.IsDefined(typeof(NUnit.Framework.TestAttribute), false))
                        {
                            //Пишем имя метода
                            Console.WriteLine(mi.Name);

                            TestMethod = TestType.GetMethod(mi.Name.ToString());

                            //запускаем SetUp метод
                            try
                            {
                                if (StartMethod != null)
                                    StartMethod.Invoke(obj, new object[] { });
                            }
                            catch (Exception e)
                            {

                            }
                            // пытаемся запустить тестовый метод, если выдает ошибку выводим ее
                            try
                            {
                                TestMethod.Invoke(obj, new object[] { });
                                Console.WriteLine("тест прошел успешно");
                                Console.WriteLine();

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("тест прошел с ошибкой");
                                Console.WriteLine(e.InnerException.Message);
                            }

                        }
                    }
                }
                break;
            }
        }
    }
}
    

