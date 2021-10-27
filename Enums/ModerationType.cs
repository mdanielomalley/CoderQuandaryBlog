using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CoderQuandaryBlog.Enums
{
    public enum ModerationType
    {
        [Description("Political Propaganda")]
        Political,
        [Description("Offensive Language")]
        Language,
        [Description("Reference to Illicit Drug Activity")]
        Drugs,
        [Description("Lewd Commentary")]
        Inappropriate,
        [Description("Threatening Speech")]
        Threatening,
        [Description("Sexual Content")]
        Sexual,
        [Description("Loathful Conversation")]
        HateSpeech,
        [Description("Pushing Standards on Others")]
        Shaming

    }
}
