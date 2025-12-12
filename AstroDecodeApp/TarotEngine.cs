using System;
using System.Collections.Generic;

namespace AstroDecodeApp
{
    public class TarotCard
    {
        public string Name { get; set; }
        public string TraditionalMeaning { get; set; }
        public string IntuitiveMeaning { get; set; }

        public TarotCard(string name, string traditional, string intuitive)
        {
            Name = name;
            TraditionalMeaning = traditional;
            IntuitiveMeaning = intuitive;
        }

        public string FullMeaning(string mode)
        {
            string modeSection = BuildModeSpecificSection(mode);
            return
                $"Card: {Name}\r\n\r\n" +
                $"Traditional meaning:\r\n{TraditionalMeaning}\r\n\r\n" +
                $"Intuitive / energetic message:\r\n{IntuitiveMeaning}\r\n\r\n" +
                modeSection;
        }

        private string BuildModeSpecificSection(string mode)
        {
            if (string.IsNullOrEmpty(mode))
                mode = "Lunar Guide (Fusion)";

            if (mode.StartsWith("Amethyst Sage"))
            {
                return
                    "Amethyst Sage reflection:\r\n" +
                    "I’m reading this card through structure and symbolism — patterns, timing, and cause-and-effect. " +
                    "Let this card be a map you can actually navigate, not just a mystery you observe.";
            }
            else if (mode.StartsWith("Through the Veil"))
            {
                return
                    "Through the Veil reflection:\r\n" +
                    "I’m feeling into the emotional current of this card — the images, the mood, the way it lands in your body. " +
                    "Notice what stirs in you as you read this, and trust the sensations that arise as part of the message.";
            }
            else // Lunar Guide (Fusion)
            {
                return
                    "Lunar Guide reflection:\r\n" +
                    "I’m holding both the traditional symbolism and your lived reality. " +
                    "Let this card be a mirror — part archetype, part personal, showing you a direction you can actually walk toward.";
            }
        }
    }

    public static class TarotEngine
    {
        private static readonly Random rng = new Random();
        private static readonly List<TarotCard> deck = new List<TarotCard>();

        static TarotEngine()
        {
            // You can expand this deck with all 22 Major Arcana later.
            deck.Add(new TarotCard(
                "0 — The Fool",
                "New beginnings, innocence, spontaneity, a leap of faith. The Fool steps into the unknown with trust, curiosity, and a willingness to discover.",
                "Energetically, this card asks: where are you standing at the edge of something new, even if you feel unprepared? " +
                "There is an invitation to move before everything feels certain, to let curiosity lead instead of fear."
            ));

            deck.Add(new TarotCard(
                "II — The High Priestess",
                "Intuition, mystery, the unconscious, inner knowing. A call to listen to what is not spoken, to honor dreams, symbols, and subtle signals.",
                "This card hums with quiet psychic awareness. It suggests that you already know more than you are admitting — " +
                "your body, your dreams, and your deeper senses have been trying to speak. It invites you to slow down and listen inward."
            ));

            deck.Add(new TarotCard(
                "III — The Empress",
                "Nurturing, abundance, creativity, fertility. The Empress represents receiving, softness, and the richness of being rather than constant doing.",
                "Energetically, this card asks where you can soften into receiving — support, care, pleasure, or rest. " +
                "It may be pointing to a part of you or your life that is hungry for nourishment and gentler self‑treatment."
            ));

            deck.Add(new TarotCard(
                "X — Wheel of Fortune",
                "Cycles, fate, turning points, change. The Wheel reminds you that life moves in seasons, and that nothing stays fixed forever.",
                "This card speaks of a shift in energy — a turning of the tide. " +
                "It may not promise specific outcomes, but it suggests that the current chapter is giving way to another, asking you to adapt and stay open."
            ));

            deck.Add(new TarotCard(
                "XIII — Death",
                "Transformation, endings, release, deep change. Not literal death, but the shedding of what can no longer continue in its current form.",
                "Energetically, this card calls for honest release — a pattern, story, or attachment that has run its course. " +
                "It often arrives when your soul has outgrown something, even if your mind is still clinging to the old shape."
            ));

            deck.Add(new TarotCard(
                "XVIII — The Moon",
                "Illusion, uncertainty, dreams, the subconscious. A time of fog, intuition, and emotional tides rather than clear, linear logic.",
                "This card mirrors emotional and psychic weather — heightened sensitivity, vivid dreams, or confusion. " +
                "It invites you to move gently, to let intuition guide step by step instead of demanding a full map right now."
            ));

            deck.Add(new TarotCard(
                "XIX — The Sun",
                "Clarity, joy, vitality, warmth. A moment of illumination, truth, and simple aliveness after a period of confusion or heaviness.",
                "Energetically, this card brings a warm, validating light. " +
                "It may be highlighting what is working, what is true, or what wants to grow when you allow yourself to feel deserving of brightness."
            ));

            deck.Add(new TarotCard(
                "XX — Judgement",
                "Awakening, reckoning, self‑evaluation. A call to answer your own deeper truth and step into a more aligned version of yourself.",
                "This card feels like a soul‑level alarm clock. " +
                "It suggests that something in you is ready to rise up, to stop repeating an old script, and to claim a more honest way of living."
            ));

            deck.Add(new TarotCard(
                "XXI — The World",
                "Completion, integration, wholeness, the end of a cycle. A moment of closure and fulfillment before a new cycle begins.",
                "Energetically, this card speaks to a chapter reaching genuine completion — not just ending, but integrating what you’ve learned. " +
                "It invites you to honor how far you’ve come, and to let that acknowledgment shape how you step into what comes next."
            ));
        }

        public static TarotCard DrawCard()
        {
            if (deck.Count == 0)
                throw new InvalidOperationException("Tarot deck is empty.");

            int index = rng.Next(deck.Count);
            return deck[index];
        }
    }
}
