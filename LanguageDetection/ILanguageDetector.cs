using System.Collections.Generic;

namespace LanguageDetection
{
    interface ILanguageDetector
    {
        double Alpha { get; set; }
        int? RandomSeed { get; set; }
        int Trials { get; set; }
        int NGramLength { get; set; }
        int MaxTextLength { get; set; }
        double AlphaWidth { get; set; }
        int MaxIterations { get; set; }
        double ProbabilityThreshold { get; set; }
        double ConvergenceThreshold { get; set; }
        int BaseFrequency { get; set; }

        void AddAllLanguages();
        void AddLanguages(params string[] languages);
        string Detect(string text);
        IEnumerable<DetectedLanguage> DetectAll(string text);
    }
}
