using System;

namespace UnivLabProj2_2 {
    public static class check {

        static public bool isokinputint(string s, int left, int right) {
            bool ok;
            int a;
            ok = int.TryParse(s, out a);
            if(ok)
                if(a < left || a > right)
                    ok = false;
            return ok;
        }
        static public bool isokinputbyte(string s, byte left, byte right) {
            bool ok;
            byte a;
            ok = byte.TryParse(s, out a);
            if(ok)
                if(a < left || a > right)
                    ok = false;
            return ok;
        }

    }
    public class Time {
        byte hours;
        byte minutes;
        byte Hours { get { return hours; } set { hours = value; } }
        byte Minutes { get { return minutes; } set { minutes = value; } }
        public Time() {
            this.hours = 0;
            this.minutes = 0;
        }
        public Time(byte hours, byte minutes) {
            this.hours = hours;
            this.minutes = minutes;
        }
        public Time(Time t) {
            this.hours = t.hours;
            this.minutes = t.minutes;
        }
        public new string ToString() {
            string str = "";
            if(hours < 10) {
                str += "0";
            }
            str += hours +":";
            if(minutes < 10) {
                str += "0";
            }
            str += minutes;
            return str;
        }
        public static Time operator -(Time t, Time t1) {
            int hours = t.hours;
            int minutes = t.minutes;
            minutes -= t1.minutes;
            if(minutes < 0) {
                hours -= 1;
                minutes = 60 + minutes;
            }
            hours -= t1.hours;
            if(hours < 0) {
                hours = 24 + hours;
            }
            return new Time(Convert.ToByte(hours), Convert.ToByte(minutes));
        }
        public static Time operator --(Time t) {
            int hours = t.hours;
            int minutes = t.minutes;
            minutes -= 1;
            if(minutes < 0) {
                hours -= 1;
                minutes = 60 + minutes;
            }
            if(hours < 0) {
                hours = 24 + hours;
            }
            return new Time(Convert.ToByte(hours), Convert.ToByte(minutes));
        }
        public static explicit operator byte(Time t) {
            return t.hours;
        }
        public static implicit operator bool(Time t) {
            return Convert.ToBoolean(t.hours) && Convert.ToBoolean(t.minutes);
        }
        public static Time operator +(Time t, Time t1) {
            int hours = t.hours;
            int minutes = t.minutes;
            minutes += t1.minutes;
            if(minutes > 59) {
                hours += minutes / 60;
                minutes %= 60;
            }
            hours += t1.hours;
            if(hours > 23) {
                hours %= 24;
            }
            return new Time(Convert.ToByte(hours), Convert.ToByte(minutes));
        }
        public static Time operator +(Time t, byte minutes1) {
            int hours = t.hours;
            int minutes = t.minutes;
            minutes += minutes1;
            if(minutes > 59) {
                hours += minutes / 60;
                minutes %= 60;
            }
            if(hours > 23) {
                hours %= 24;
            }
            return new Time(Convert.ToByte(hours), Convert.ToByte(minutes));
        }
        public static Time operator +(byte minutes1, Time t) {
            int hours = t.hours;
            int minutes = t.minutes;
            minutes += minutes1;
            if(minutes > 59) {
                hours += minutes / 60;
                minutes %= 60;
            }
            if(hours > 23) {
                hours %= 24;
            }
            return new Time(Convert.ToByte(hours), Convert.ToByte(minutes));
        }
    }
    class Program {
        static void Main(string[] args) {
            Time time = new Time();
            Console.WriteLine("Time().ToString: " + time.ToString());

            string inp;
            string[] spl;
            Time time1;
            while(true) {
                Console.WriteLine("Input hours and minutes for Time1(hours, minutes):");
                inp = Console.ReadLine();
                spl = inp.Split(' ');
                if(spl.Length == 2) {
                    if(check.isokinputbyte(spl[0], 0, 23) && check.isokinputbyte(spl[1], 0, 59)) {
                        time1 = new Time(Convert.ToByte(spl[0]), Convert.ToByte(spl[1]));
                        Console.WriteLine("Time1(hours, minutes).ToString: " + time1.ToString());
                        break;
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }
                } else {
                    Console.Out.WriteLine("Input Error.");
                }
            }

            Time time2 = new Time(time1);
            Console.WriteLine("Time2(Time1).ToString: " + time2.ToString());

            Time t11, t12;
            while(true) {
                Console.WriteLine("Input hours and minutes for Time11(hours, minutes) and for Time12(hours, minutes) for Time(12, 0) - Time(1, 22)).ToString: ");
                inp = Console.ReadLine();
                spl = inp.Split(' ');
                if(spl.Length == 4) {
                    if(check.isokinputbyte(spl[0], 0, 23) && check.isokinputbyte(spl[1], 0, 59) && check.isokinputbyte(spl[2], 0, 23) && check.isokinputbyte(spl[3], 0, 59)) {
                        t11 = new Time(Convert.ToByte(spl[0]), Convert.ToByte(spl[1]));
                        t12 = new Time(Convert.ToByte(spl[2]), Convert.ToByte(spl[3]));
                        Console.WriteLine("(Time11(hours, minutes) - Time12(hours, minutes)).ToString: " + (t11 - t12).ToString());
                        break;
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }
                } else {
                    Console.Out.WriteLine("Input Error.");
                }
            }

            Time t4;
            while(true) {
                Console.WriteLine("Input hours and minutes for Time4(hours, minutes) for (--Time4(hours, minutes)).ToString:");
                inp = Console.ReadLine();
                spl = inp.Split(' ');
                if(spl.Length == 2) {
                    if(check.isokinputbyte(spl[0], 0, 23) && check.isokinputbyte(spl[1], 0, 59)) {
                        t4 = new Time(Convert.ToByte(spl[0]), Convert.ToByte(spl[1]));
                        Console.WriteLine("(--Time4(hours, minutes)).ToString: " + (--t4).ToString());
                        break;
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }
                } else {
                    Console.Out.WriteLine("Input Error.");
                }
            }

            Time t6;
            byte b;
            while(true) {
                Console.WriteLine("Input hours and minutes for Time6(hours, minutes) and b minutes for (Time6(hours, minutes) + b).ToString:");
                inp = Console.ReadLine();
                spl = inp.Split(' ');
                if(spl.Length == 3) {
                    if(check.isokinputbyte(spl[0], 0, 23) && check.isokinputbyte(spl[1], 0, 59) && check.isokinputbyte(spl[2],byte.MinValue,byte.MaxValue)) {
                        t6 = new Time(Convert.ToByte(spl[0]), Convert.ToByte(spl[1]));
                        b = Convert.ToByte(spl[2]);
                        Console.WriteLine("(Time6(hours, minutes) + b).ToString: " + (t6+b).ToString());
                        break;
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }
                } else {
                    Console.Out.WriteLine("Input Error.");
                }
            }

            Time t7;
            byte c;
            while(true) {
                Console.WriteLine("Input hours and minutes for Time7(hours, minutes) and c minutes for (c + Time6(hours, minutes)).ToString:");
                inp = Console.ReadLine();
                spl = inp.Split(' ');
                if(spl.Length == 3) {
                    if(check.isokinputbyte(spl[0], 0, 23) && check.isokinputbyte(spl[1], 0, 59) && check.isokinputbyte(spl[2], byte.MinValue, byte.MaxValue)) {
                        t7 = new Time(Convert.ToByte(spl[0]), Convert.ToByte(spl[1]));
                        c = Convert.ToByte(spl[2]);
                        Console.WriteLine("(c + Time6(hours, minutes)+b).ToString: " + (c + t7).ToString());
                        break;
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }
                } else {
                    Console.Out.WriteLine("Input Error.");
                }
            }

            Time t15, t16;
            while(true) {
                Console.WriteLine("Input hours and minutes for Time15(hours, minutes) and Time16(hours, minutes) for Time15(hours, minutes) + Time16(hours, minutes)).ToString: ");
                inp = Console.ReadLine();
                spl = inp.Split(' ');
                if(spl.Length == 4) {
                    if(check.isokinputbyte(spl[0], 0, 23) && check.isokinputbyte(spl[1], 0, 59) && check.isokinputbyte(spl[2], 0, 23) && check.isokinputbyte(spl[3], 0, 59) ){
                        t15 = new Time(Convert.ToByte(spl[0]), Convert.ToByte(spl[1]));
                        t16 = new Time(Convert.ToByte(spl[2]), Convert.ToByte(spl[3]));
                        Console.WriteLine("Time15(hours, minutes) + Time16(hours, minutes)).ToString: " + (t15 + t16).ToString());
                        break;
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }
                } else {
                    Console.Out.WriteLine("Input Error.");
                }
            }

            Time t8;
            while(true) {
                Console.WriteLine("Input hours and minutes for Time8(hours, minutes) for ((byte)Time8(hours, minutes))");
                inp = Console.ReadLine();
                spl = inp.Split(' ');
                if(spl.Length == 2) {
                    if(check.isokinputbyte(spl[0], 0, 23) && check.isokinputbyte(spl[1], 0, 59)) {
                        t8 = new Time(Convert.ToByte(spl[0]), Convert.ToByte(spl[1]));
                        Console.WriteLine("((byte)Time8(hours, minutes)): " + ((byte)t8));
                        break;
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }
                } else {
                    Console.Out.WriteLine("Input Error.");
                }
            }

            Time t9;
            while(true) {
                Console.WriteLine("Input hours and minutes for Time9(hours, minutes) for (Time9(hours, minutes)) == true)");
                inp = Console.ReadLine();
                spl = inp.Split(' ');
                if(spl.Length == 2) {
                    if(check.isokinputbyte(spl[0], 0, 23) && check.isokinputbyte(spl[1], 0, 59)) {
                        t9 = new Time(Convert.ToByte(spl[0]), Convert.ToByte(spl[1]));
                        Console.WriteLine("(Time9(hours, minutes)) == true): " + (t9 == true));
                        break;
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }
                } else {
                    Console.Out.WriteLine("Input Error.");
                }
            }

        }
    }
}
ы
