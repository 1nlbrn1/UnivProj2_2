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

    }
    public class Time {
        byte hours;
        byte minutes;
        byte Hours { get; set; }
        byte Minutes { get; set; }
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
            return hours + ":" + minutes;
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
        /*
        public static Time operator -(Time t, byte minutes1) { // доработать
            int hours = t.hours;
            int minutes = t.minutes;
            minutes -= minutes1;
            if(minutes < 0) {
                hours += minutes/60 - 1;
                minutes = 60 + minutes%60;
            }
            if(hours < 0) {
                hours = 24 + hours;
            }
            return new Time(Convert.ToByte(hours), Convert.ToByte(minutes));
        }
        */
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
                Console.WriteLine(minutes + " " + minutes / 60);
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
            Time t = new Time(12, 0);
            Time t1 = new Time(1, 22);
            Console.WriteLine((t - t1).ToString());

            Time t2 = new Time(12, 0);
            Time t3 = new Time(14, 22);
            Console.WriteLine((t2 - t3).ToString());

            Time t4 = new Time(12, 0);
            Console.WriteLine((--t4).ToString());

            Time t5 = new Time(0, 0);
            Console.WriteLine((--t5).ToString());

            Time t6 = new Time(12, 0);
            byte a = 12;
            Console.WriteLine((t6 + a).ToString());

            Time t7 = new Time(1, 0);
            byte b = 66;
            Console.WriteLine((b + t7).ToString());

            Time t77 = new Time(1, 0);
            byte bb = 126;
            Console.WriteLine((bb + t77).ToString());

            Time t8 = new Time(13, 33);
            Console.WriteLine(((byte)t8));

            Time t9 = new Time(13, 33);
            Console.WriteLine(((bool)t9));

            Time t10 = new Time(0, 1);
            Console.WriteLine(((bool)t10));
        }
    }
}
