using System.Collections.Generic;

namespace LanguageDetection
{
    public class LanguageDetector : ILanguageDetector
    {
        private const string BaseResourceNamePrefix = "LanguageDetection.Profiles.";
        private const string ShortTextResourceNamePrefix = BaseResourceNamePrefix + "ShortText.";

        private readonly ILanguageDetector baseLangDetect;
        private readonly ILanguageDetector shortTextLangDetect;

        public LanguageDetector()
        {
            baseLangDetect = new LanguageDetectorBase(BaseResourceNamePrefix);
            shortTextLangDetect = new LanguageDetectorBase(ShortTextResourceNamePrefix);
            ShortTextLength = 25;
        }

        public double Alpha
        {
            get { return baseLangDetect.Alpha; }
            set
            {
                baseLangDetect.Alpha = value;
                shortTextLangDetect.Alpha = value;
            }
        }

        public int? RandomSeed
        {
            get { return baseLangDetect.RandomSeed; }
            set
            {
                baseLangDetect.RandomSeed = value;
                shortTextLangDetect.RandomSeed = value;
            }
        }

        public int Trials
        {
            get { return baseLangDetect.Trials; }
            set
            {
                baseLangDetect.Trials = value;
                shortTextLangDetect.Trials = value;
            }
        }

        public int NGramLength
        {
            get { return baseLangDetect.NGramLength; }
            set
            {
                baseLangDetect.NGramLength = value;
                shortTextLangDetect.NGramLength = value;
            }
        }

        public int MaxTextLength
        {
            get { return baseLangDetect.MaxTextLength; }
            set
            {
                baseLangDetect.MaxTextLength = value;
                shortTextLangDetect.MaxTextLength = value;
            }
        }

        public double AlphaWidth
        {
            get { return baseLangDetect.AlphaWidth; }
            set
            {
                baseLangDetect.AlphaWidth = value;
                shortTextLangDetect.AlphaWidth = value;
            }
        }

        public int MaxIterations
        {
            get { return baseLangDetect.MaxIterations; }
            set
            {
                baseLangDetect.MaxIterations = value;
                shortTextLangDetect.MaxIterations = value;
            }
        }

        public double ProbabilityThreshold
        {
            get { return baseLangDetect.ProbabilityThreshold; }
            set
            {
                baseLangDetect.ProbabilityThreshold = value;
                shortTextLangDetect.ProbabilityThreshold = value;
            }
        }

        public double ConvergenceThreshold
        {
            get { return baseLangDetect.ConvergenceThreshold; }
            set
            {
                baseLangDetect.ConvergenceThreshold = value;
                shortTextLangDetect.ConvergenceThreshold = value;
            }
        }

        public int BaseFrequency
        {
            get { return baseLangDetect.BaseFrequency; }
            set
            {
                baseLangDetect.BaseFrequency = value;
                shortTextLangDetect.BaseFrequency = value;
            }
        }

        public int ShortTextLength { get; set; }

        public void AddAllLanguages()
        {
            baseLangDetect.AddAllLanguages();
            shortTextLangDetect.AddAllLanguages();
        }

        public void AddLanguages(params string[] languages)
        {
            baseLangDetect.AddLanguages(languages);
            shortTextLangDetect.AddLanguages(languages);
        }

        public string Detect(string text)
        {
            return GetDetector(text).Detect(text);
        }

        public IEnumerable<DetectedLanguage> DetectAll(string text)
        {
            return GetDetector(text).DetectAll(text);
        }

        private ILanguageDetector GetDetector(string text)
        {
            return text == null || text.Length > ShortTextLength
                ? baseLangDetect
                : shortTextLangDetect;
        }
    }
}
