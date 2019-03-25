/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Text.RegularExpressions;

namespace RtfCreator
{
    public class RtfCreator
    {
        public enum MarkType { ForeColor, BackGround/*, System*/ }
        string text;
        List<MarkedText> Markeds = new List<MarkedText>();
        private static Hashtable colorsTypes = new Hashtable();
        private static StringBuilder colorTbl = new StringBuilder();
        public static void AddColor(string colorType, Color Color)
        {
            if (colorsTypes.Contains(colorType)) return;
            colorsTypes.Add(colorType, (colorsTypes.Count + 1).ToString());
            colorTbl.Append(string.Format(@"\red{0}\green{1}\blue{2};", Color.R, Color.G, Color.B));
        }
        public void UnMarkAll(MarkType type)
        {
            for (int i = 0; i < Markeds.Count; /*i++*/)
                if (Markeds[i].Type == type)
                    Markeds.RemoveAt(i);
                else i++;
        }
        public void MarkText(MarkType type, string colortype, int fromChar, int chars)
        {
            if (chars != 0)
                Markeds.Add(new MarkedText(type, colortype, fromChar, chars));
            return;


        }

        private RtfCreator() { }
        public RtfCreator(string text)
        {
            this.text = text;
        }

        public string Text
        {
            get { return text; }
        }

        public string Rtf
        {
            get
            {
                Hashtable bounds = GetMarkedBounds();
                MarkerBound bnd;
                string currentAdd = string.Empty;
                StringBuilder sb = new StringBuilder(text.Length + bounds.Count + 3);
                sb.Append(@"{\rtf1 ");
                sb.Append(@"{\colortbl ;" + colorTbl.ToString() + "}");
                for (int i = 0; i < text.Length; i++)
                {
                    //bnd=bounds[i] is MarkerBound;
                    switch (text[i])
                    {
                        case '\r':
                            currentAdd = "";
                            break;
                        case '\n':
                            currentAdd = @"\par" + "\n";
                            break;
                        default:
                            currentAdd = @"\u" + ((int)(text[i])).ToString() + ";";
                            break;
                    }
                    if (!(bounds[i] is MarkerBound))
                        sb.Append(currentAdd);
                    else
                    {
                        bnd = (MarkerBound)bounds[i];
                        /*if (bnd.IsBegin)*/
                        sb.Append(bnd.RtfCommand + currentAdd);
                        //else sb.Append(currentAdd + bnd.RtfCommand);
                    }
                }
                sb.Append("}");
                return sb.ToString();
            }
        }

        private Hashtable GetMarkedBounds()
        {
            Hashtable markersBounds = new Hashtable(Markeds.Count * 2);
            string cmdVal = string.Empty;
            string cmdColorNumber;
            MarkerBound bound;
            for (int i = 0; i < Markeds.Count; i++)
            {

                switch (Markeds[i].Type)
                {
                    case MarkType.ForeColor:
                        cmdVal = @"\cf";
                        break;
                    case MarkType.BackGround:
                        cmdVal = @"\highlight";
                        break;
                    default:
                        break;
                }

                cmdColorNumber = (string)(colorsTypes[Markeds[i].ColorType]);
                bound = new MarkerBound(true, cmdVal + cmdColorNumber + " ");
                if (markersBounds[Markeds[i].From] == null)
                    markersBounds.Add(Markeds[i].From, bound);
                else
                    markersBounds[Markeds[i].From] = ((MarkerBound)markersBounds[Markeds[i].From]).AddCommand(bound.RtfCommand);

                cmdColorNumber = "0";
                bound = new MarkerBound(false, cmdVal + cmdColorNumber + " ");
                if (markersBounds[Markeds[i].To] == null)
                    markersBounds.Add(Markeds[i].To, bound);
                else
                    markersBounds[Markeds[i].To] = ((MarkerBound)markersBounds[Markeds[i].To]).AddCommand(bound.RtfCommand);

            }
            return markersBounds;
        }




        struct MarkerBound
        {
            public bool IsBegin;
            public string RtfCommand;
            public MarkerBound(bool IsBegin, string RtfCommand)
            {
                this.IsBegin = IsBegin;
                this.RtfCommand = RtfCommand;
            }
            public MarkerBound AddCommand(string cmd)
            {
                return new MarkerBound(IsBegin, RtfCommand + cmd);
            }

        }
        struct MarkedText
        {
            public int From;
            public int To;
            public MarkType Type;
            public string ColorType;
            public MarkedText(MarkType Type, string ColorType, int From, int Chars)
            {
                this.Type = Type;
                this.ColorType = ColorType;
                this.From = From;
                this.To = From + Chars;
            }

        }
    }
}
