using System.Text;

namespace configVar
{
    static public class ConfigParser
    {
        enum ParserState
        {
            Name,
            StartValue,
            Value
        }

        static public void Parse(string text)
        {
            ParserState state = ParserState.Name;

            StringBuilder currVal = new StringBuilder();
            bool isQuoted = false;
            string name = "";
            for (int i = 0; i < text.Length; ++i)
            {
                char c = text[i];

                switch (state)
                {
                    case ParserState.Name:
                        if (IsWhiteSpace(c) || c == ';')
                            continue;

                        if (c == '=')
                        {
                            // finalize name
                            name = currVal.ToString();
                            currVal.Clear();
                            state = ParserState.StartValue;
                            continue;
                        }
                        break;

                    case ParserState.StartValue:
                        if (IsWhiteSpace(c))
                            continue;

                        if (c == '"')
                        {
                            isQuoted = true;
                            continue;
                        }

                        state = ParserState.Value;
                        break;
                    case ParserState.Value:
                        if (c == ';' || ( isQuoted && c == '"' ))
                        {
                            // finalize var
                            ConfigRegistry.Set(name, currVal.ToString());
                            currVal.Clear();
                            state = ParserState.Name;
                            isQuoted = false;
                            continue;
                        }
                        break;
                }

                currVal.Append(c);
            }
        }

        static bool IsWhiteSpace(char c)
        {
            return c == ' ' || c == '\t' || c == '\n' || c == '\r';
        }
    }
}
