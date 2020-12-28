using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.AssemblerCore
{
    class Core
    {
        //Глобальный массив комманд
        private string[] Commands;
        // Регистры
        private int R0, R1, R2, R3;

        //Создаем конструктор в который передаем команды
        public Core(string[] commands)
        {
            Commands = commands;
        }

        //Метод начинающий выполнение кода
        public void execude(MainWindow window)
        {
            //Пробегаемся по всем коммандам
            foreach(string command in Commands)
            {
                ArrayList list = CheckComand(command);
                if(list != null)
                {
                    string cmd = list[0].ToString();
                    string register = list[1].ToString();
                    string value = list[2].ToString();

                    switch (cmd)
                    {
                        case "mov":
                            {
                                mov(register, value, window);
                                break;
                            }
                        case "add":
                            {
                                add(register, value, window);
                                break;
                            }
                        case "sub":
                            {
                                sub(register, value, window);
                                break;
                            }
                        case "mul":
                            {
                                mul(register, value, window);
                                break;
                            }
                        case "div":
                            {
                                div(register, value, window);
                                break;
                            }
                        default:
                            {
                                window.ShowError("Неизвестная комманда: '" + cmd + "'");
                                break;
                            }
                    }
                } else
                {
                    window.ShowError("Не удалось распарсить комманду: '" + command + "'");
                }
            }
            window.UpdateUIRegister(R0, R1, R2, R3);
        }

        private void mov(string register, string value, MainWindow window)
        {
            int v = getValue(value, window);
            switch(register)
            {
                case "R0":
                    {
                        R0 = v;
                        break;
                    }
                case "R1":
                    {
                        R1 = v;
                        break;
                    }
                case "R2":
                    {
                        R2 = v;
                        break;
                    }
                case "R3":
                    {
                        R3 = v;
                        break;
                    }
                default:
                    {
                        window.ShowError("Неизвестный регистр: '" + register + "'");
                        break;
                    }
            }
        }

        private void add(string register, string value, MainWindow window)
        {
            int v = getValue(value, window);
            switch (register)
            {
                case "R0":
                    {
                        R0 += v;
                        break;
                    }
                case "R1":
                    {
                        R1 += v;
                        break;
                    }
                case "R2":
                    {
                        R2 += v;
                        break;
                    }
                case "R3":
                    {
                        R3 += v;
                        break;
                    }
                default:
                    {
                        window.ShowError("Неизвестный регистр: '" + register + "'");
                        break;
                    }
            }
        }

        private void sub(string register, string value, MainWindow window)
        {
            int v = getValue(value, window);
            switch (register)
            {
                case "R0":
                    {
                        R0 -= v;
                        break;
                    }
                case "R1":
                    {
                        R1 -= v;
                        break;
                    }
                case "R2":
                    {
                        R2 -= v;
                        break;
                    }
                case "R3":
                    {
                        R3 -= v;
                        break;
                    }
                default:
                    {
                        window.ShowError("Неизвестный регистр: '" + register + "'");
                        break;
                    }
            }
        }

        private void mul(string register, string value, MainWindow window)
        {
            int v = getValue(value, window);
            switch (register)
            {
                case "R0":
                    {
                        R0 *= v;
                        break;
                    }
                case "R1":
                    {
                        R1 *= v;
                        break;
                    }
                case "R2":
                    {
                        R2 *= v;
                        break;
                    }
                case "R3":
                    {
                        R3 *= v;
                        break;
                    }
                default:
                    {
                        window.ShowError("Неизвестный регистр: '" + register + "'");
                        break;
                    }
            }
        }

        private void div(string register, string value, MainWindow window)
        {
            int v = getValue(value, window);
            switch (register)
            {
                case "R0":
                    {
                        R0 /= v;
                        break;
                    }
                case "R1":
                    {
                        R1 /= v;
                        break;
                    }
                case "R2":
                    {
                        R2 /= v;
                        break;
                    }
                case "R3":
                    {
                        R3 /= v;
                        break;
                    }
                default:
                    {
                        window.ShowError("Неизвестный регистр: '" + register + "'");
                        break;
                    }
            }
        }

        private int getValue(string value, MainWindow window)
        {
            try
            {
                return int.Parse(value);
            } catch
            {
                switch (value.Replace(" ", ""))
                {
                    case "R0":
                        {
                            return R0;
                        }
                    case "R1":
                        {
                            return R1;
                        }
                    case "R2":
                        {
                            return R2;
                        }
                    case "R3":
                        {
                            return R3;
                        }
                    default:
                        {
                            window.ShowError("Неизвестное значение: '" + value + "'" + ". Значение по умолчанию - 0");
                            break;
                        }
                }
            }
            return 0;
        }

        /*
         * Возвращает ArrayList в котором 
         * 0 элемент - Комманда
         * 1 элемент - Регистр
         * 2 элемент - Значение
         */
        private ArrayList CheckComand(string command)
        {
            //Комманда
            StringBuilder cmd = new StringBuilder();
            //Регистр
            StringBuilder register = new StringBuilder();
            try
            {
                //Проходим строку до пробела, это комманда
                foreach (char c in command)
                {
                    if (c != ' ')
                    {
                        cmd.Append(c);
                    }
                    else
                    {
                        break;
                    }
                }
                //Получаем новую строку, удалив из начальной комманду
                string temp = command.Remove(0, cmd.Length + 1);
                foreach (char c in temp)
                {
                    if (c != ',')
                    {
                        register.Append(c);
                    }
                    else
                    {
                        break;
                    }
                }
                //Получаем значение, удалив из строки с регистром - регистр
                temp = temp.Remove(0, register.Length + 1);
                ArrayList list = new ArrayList();
                list.Add(cmd.ToString());
                list.Add(register.ToString());
                list.Add(temp);
                return list;
                    
            } catch(Exception e)
            {
                return null;
            }
        }
    }
}
