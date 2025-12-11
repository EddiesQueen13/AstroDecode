namespace AstroDecodeApp
{
    public static class AstrologyEngine
    {
        public static string GetResponse(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
                return "Ask me something about astrology.";

            // Simple placeholder logic
            if (question.ToLower().Contains("aries"))
                return "Aries energy is bold, fiery, and ready to take action.";

            if (question.ToLower().Contains("moon"))
                return "The Moon represents emotions, intuition, and your inner world.";

            if (question.ToLower().Contains("rising"))
                return "Your rising sign describes how others see you and your outward personality.";

            return "Interesting question. I’ll have deeper astrology insights soon!";
        }
    }
}
