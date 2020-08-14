using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Codec
{
    class FrameCodec
    {
        private int n;
        public FrameCodec(int n)
        {
            this.n = n;
        }
        public string FrameCodecWork(string s)
        {
            if(n>0)
            {
                for (int i = n; i > 0; i--)
                {
                    s = s + i;
                    s = i + s;
                }
                return s;
            }else
            {
                for(int i=0; i < Math.Abs(n); i++)
                {
                    s = s.Remove(s.Length - 1,1);
                    s = s.Remove(0,1);
                }
                return s;
            }

        }
    }
    class ReverseCodec
    {
        public string ReverseCodecWork(string s)
        {
            char[] bufArr = s.ToCharArray();
            Array.Reverse(bufArr);
            return new string(bufArr);
        }
    }
    class PushCodec
    {
        private int n;
        public PushCodec(int n)
        {
            this.n = n;
        }
        public string PushCodecWork(string s)
        {
            for(int i=0; i<Math.Abs(n); i++)
            {
                if(n<0)
                {
                    s = s.Remove(0, 1) + s.Substring(0, 1);
                }
                    else
                        {
                            s = s.Substring(s.Length - 1, 1) + s.Remove(s.Length - 1, 1);
                        }
               
            }
            return s;
        }
    }
    class CezarCodec
    {
        private int n;
        public CezarCodec(int n)
        {
            this.n = n;
        }
        public string CezarCodecWork(string s)
        {
            string output = string.Empty;
            for(int i=0; i<s.Length; i++)
            {
                int buf = s[i] - '0';
                buf = buf + n % 10;
                if (buf < 0)
                    buf = buf + 10;

                if (buf > 9)
                    buf = buf % 10;

                output = output + buf;
            }
            return output;
        }
    }
    class SwapCodec
    {
        public string SwapCodecWork(string s)
        {
            string output = string.Empty;
            int i;
            for (i = 0; i < s.Length; i += 2)
            {
                if(i+1 < s.Length)
                    output += s[i + 1];
                output += s[i];
            }
            return output;
        }
    }
}
