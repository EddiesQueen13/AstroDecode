using System;
using System.Collections.Generic;
using System.Linq;

namespace AstroDecodeApp
{
    public static class AstrologyEngine
    {
        private static readonly Dictionary<string, string> Signs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "aries", "Aries is cardinal fire: initiation, courage, raw life force, and the urge to move first. Its energy is direct, bold, impatient, and often deeply honest. At its best, Aries teaches you to act, to stand up for yourself, and to honor your instinct even when others hesitate." },
            { "taurus", "Taurus is fixed earth: grounding, stability, embodiment, and sensual presence. It craves safety, beauty, and comfort, and often moves slowly but with great persistence. At its best, Taurus teaches you how to build something lasting, enjoy the physical world, and trust your own pace." },
            { "gemini", "Gemini is mutable air: curiosity, language, mental flexibility, and the urge to connect. It gathers data, asks questions, and rarely sits still for long. At its best, Gemini teaches you how to hold multiple perspectives, stay open, and let conversation become a path to self‑discovery." },
            { "cancer", "Cancer is cardinal water: emotional protection, nurturing, and roots. It is sensitive to the unseen, attuned to memory, and often guards its vulnerable heart. At its best, Cancer teaches you how to care for yourself and others, honor your feelings, and recognize that softness is not weakness." },
            { "leo", "Leo is fixed fire: self‑expression, radiance, and the sacred inner child. It wants to be seen, but more importantly, it wants to live from the heart. At its best, Leo teaches you how to take up space, create boldly, and remember that joy itself is a form of spiritual power." },
            { "virgo", "Virgo is mutable earth: refinement, service, discernment, and deep noticing. It sees details others miss, and often carries quiet standards of excellence. At its best, Virgo teaches you to heal through small, consistent adjustments, and to treat your own body and routines as sacred." },
            { "libra", "Libra is cardinal air: relating, balance, and the art of harmony. It is drawn to beauty, fairness, and understanding both sides. At its best, Libra teaches you how to co‑create with others, honor your needs alongside theirs, and find justice without losing your heart." },
            { "scorpio", "Scorpio is fixed water: intensity, depth, and transformation. It sees beneath the surface and is rarely satisfied with small talk. At its best, Scorpio teaches you how to face the shadow, hold complexity, and emerge from your own underworld with more power and truth." },
            { "sagittarius", "Sagittarius is mutable fire: exploration, freedom, meaning‑making, and faith. It seeks the horizon — physical, mental, spiritual. At its best, Sagittarius teaches you to trust your quest for truth, laugh in the face of fear, and remember that belief can be a flame you carry." },
            { "capricorn", "Capricorn is cardinal earth: structure, responsibility, legacy, and long‑term vision. It climbs slowly but relentlessly. At its best, Capricorn teaches you to define success on your terms, respect your time and effort, and build a life that your future self will thank you for." },
            { "aquarius", "Aquarius is fixed air: future‑minded, unconventional, and deeply concerned with the collective. It values authenticity over fitting in. At its best, Aquarius teaches you how to stand outside the system, imagine better worlds, and refuse to betray your truth for approval." },
            { "pisces", "Pisces is mutable water: dreams, dissolution, compassion, and spiritual blending. It feels what others cannot name. At its best, Pisces teaches you how to surrender without abandoning yourself, let creativity move through you, and recognize that everything is connected on some level." }
        };

        private static readonly Dictionary<string, string> Planets = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "sun", "The Sun describes your core vitality, ego, and the story of who you are becoming. It is where you shine, but also where you may feel pressured to perform or prove yourself." },
            { "moon", "The Moon speaks to your emotional body, instinctive needs, and private self. It reveals what helps you feel safe, soothed, and truly held — even when no one is watching." },
            { "mercury", "Mercury rules the mind: how you think, speak, learn, and process information. It shows how you communicate and how you make sense of your world." },
            { "venus", "Venus governs love, beauty, values, and the ways you open to pleasure and connection. It reveals how you give and receive affection, and what feels truly beautiful to you." },
            { "mars", "Mars rules desire, drive, anger, and the ways you pursue what you want. It shows how you assert yourself, fight for your needs, and move toward your goals." },
            { "jupiter", "Jupiter expands whatever it touches: growth, abundance, faith, and opportunity. It points to where you are invited to trust, to take risks, and to grow beyond your comfort zone." },
            { "saturn", "Saturn represents boundaries, lessons, limits, and long‑term commitments. It can feel heavy, but it also shows where you are building real strength and mastery over time." },
            { "uranus", "Uranus is disruption, awakening, and liberation. It can bring shocks that ultimately free you from what is too small or too rigid for your soul." },
            { "neptune", "Neptune blurs boundaries and dissolves illusions. It rules dreams, spirituality, longing, and sometimes confusion. It invites you to see beyond the literal into the symbolic." },
            { "pluto", "Pluto is deep transformation, power, death‑rebirth cycles, and the underworld of your psyche. It brings what is hidden to the surface so it can be faced and transmuted." }
        };

        private static readonly Dictionary<string, string> Houses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "1st house", "The 1st house is the mask and the doorway: how you appear, your instinctive way of moving through the world, and the first impression you give others." },
            { "2nd house", "The 2nd house is value, money, body, and self‑worth. It speaks to how you earn, what you cling to, and how you relate to your own resources." },
            { "3rd house", "The 3rd house covers communication, siblings, local environment, and the stories you tell yourself day‑to‑day." },
            { "4th house", "The 4th house is home, roots, ancestry, and emotional foundations. It describes where you retreat and what 'home' means to your soul." },
            { "5th house", "The 5th house is creativity, joy, romance, and the inner child. It is where you play and express your uniqueness." },
            { "6th house", "The 6th house rules daily routines, health, service, and small but consistent efforts that shape your reality." },
            { "7th house", "The 7th house is one‑to‑one partnerships, mirrors, and how you meet 'the other' in your life." },
            { "8th house", "The 8th house is intimacy, shared resources, secrets, and the deep transformations that happen behind closed doors." },
            { "9th house", "The 9th house is belief, higher learning, travel, and your personal quest for meaning." },
            { "10th house", "The 10th house is career, public image, reputation, and the legacy you are building." },
            { "11th house", "The 11th house is friendships, community, networks, and the future you imagine with others." },
            { "12th house", "The 12th house is the unconscious, dreams, solitude, and all that lives just beyond the veil of ordinary awareness." }
        };

        private static readonly Dictionary<string, string> TarotMajors = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "the fool", "The Fool is the leap of faith, the sacred beginning, and the part of you willing to step into the unknown without all the answers." },
            { "the magician", "The Magician is focused intention, will, and the ability to channel energy into form. It reminds you that your words and choices are spells." },
            { "the high priestess", "The High Priestess is intuition, mystery, and inner knowing. She sits at the threshold between seen and unseen, inviting you to listen within." },
            { "the empress", "The Empress is fertility, creativity, nurture, and abundance. She invites you to soften into receiving and to remember that you, too, are worthy of care." },
            { "the emperor", "The Emperor is structure, boundaries, and self‑authority. He asks where you need to claim your space and protect what matters." },
            { "the hierophant", "The Hierophant is tradition, systems, spiritual lineage, and sometimes the tension between external rules and inner truth." },
            { "the lovers", "The Lovers is choice, alignment, and connection. It often speaks to the question: Are your actions in harmony with your heart?" },
            { "the chariot", "The Chariot is movement, determination, and harnessing opposing forces to move forward with purpose." },
            { "strength", "Strength is inner courage, gentle power, and learning to soothe the beast rather than fight it with violence." },
            { "the hermit", "The Hermit is solitude, inner guidance, and the willingness to step away from noise to hear your own soul." },
            { "wheel of fortune", "The Wheel of Fortune is cycles, fate, and the turning of seasons in your life. It reminds you that nothing stays the same forever." },
            { "justice", "Justice is balance, truth, and consequences. It asks you to look clearly at cause and effect — both outer and inner." },
            { "the hanged man", "The Hanged Man is surrender, pause, and seeing things from a new angle. It often appears when you are suspended between what was and what will be." },
            { "death", "Death is transformation, endings, and composting what no longer serves. It is less about literal death and more about the rebirth on the other side of letting go." },
            { "temperance", "Temperance is integration, alchemy, and the art of mixing extremes into something healing and whole." },
            { "the devil", "The Devil is attachment, temptation, and the illusions that keep you feeling small or trapped. It invites you to notice where you are giving your power away." },
            { "the tower", "The Tower is sudden change, revelation, and structures that crumble when they are no longer aligned with truth." },
            { "the star", "The Star is hope, healing, and quiet renewal. It follows the Tower, bringing a soft light back after disruption." },
            { "the moon", "The Moon is dreams, subconscious, and the things that move under the surface of your awareness. It asks you to walk by intuition, not just logic." },
            { "the sun", "The Sun is joy, clarity, and life‑force. It illuminates, warms, and reminds you that you are allowed to exist in full brightness." },
            { "judgement", "Judgement is awakening, reckoning, and the call to rise into a more honest version of yourself." },
            { "the world", "The World is completion, wholeness, and the sense of a cycle closing in a meaningful way." }
        };

        private static readonly Dictionary<string, string> Chakras = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "root", "The Root chakra is safety, survival, and your relationship to the material world and your body. When balanced, you feel grounded and present." },
            { "sacral", "The Sacral chakra is creativity, desire, emotion, and pleasure. It governs how you relate to your own needs and feelings." },
            { "solar plexus", "The Solar Plexus chakra is will, confidence, and personal power. It is the fire in your belly to act and to choose." },
            { "heart", "The Heart chakra is love, compassion, and connection. It bridges the earthly and the spiritual through relationship and empathy." },
            { "throat", "The Throat chakra is expression, truth, and the ability to speak what is real for you." },
            { "third eye", "The Third Eye chakra is intuition, vision, and inner sight. It helps you perceive patterns and meaning beyond the obvious." },
            { "crown", "The Crown chakra is spiritual connection, openness to guidance, and your sense of being part of something larger than yourself." }
        };

        private static readonly Dictionary<string, string> DreamSymbols = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "water", "Water in dreams often speaks to emotions, the subconscious, and what you are feeling but not fully naming yet." },
            { "house", "A house in dreams can represent the self, your psyche, or different 'rooms' of your inner world." },
            { "teeth", "Teeth in dreams often relate to power, communication, and anxieties about change or loss of control." },
            { "flying", "Flying dreams often point to freedom, perspective, or a desire to rise above constraints." },
            { "falling", "Falling dreams can speak to fear of failure, lack of control, or transitions where you don’t yet see the ground." }
        };

        private static readonly string[] ShadowKeywords = new[]
        {
            "shadow", "wound", "trauma", "fear", "abandonment", "rejection", "betrayal", "inner child",
            "pattern", "self-sabotage", "addiction", "control", "obsession", "shame", "guilt"
        };

        public static string GetResponse(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                return "Ask me something real — about your chart, your patterns, your dreams, or the energies moving through your life. I’m listening.";
            }

            string q = question.Trim();
            string lower = q.ToLowerInvariant();

            var pieces = new List<string>();

            // 1. Detect astrology signs
            var signMatches = Signs.Keys.Where(k => lower.Contains(k)).ToList();
            foreach (var sign in signMatches)
            {
                pieces.Add(Signs[sign]);
            }

            // 2. Detect planets
            var planetMatches = Planets.Keys.Where(k => lower.Contains(k)).ToList();
            foreach (var planet in planetMatches)
            {
                pieces.Add(Planets[planet]);
            }

            // 3. Detect houses
            var houseMatches = Houses.Keys.Where(k => lower.Contains(k)).ToList();
            foreach (var house in houseMatches)
            {
                pieces.Add(Houses[house]);
            }

            // 4. Detect tarot majors
            var tarotMatches = TarotMajors.Keys.Where(k => lower.Contains(k)).ToList();
            foreach (var card in tarotMatches)
            {
                pieces.Add(TarotMajors[card]);
            }

            // 5. Detect chakras
            var chakraMatches = Chakras.Keys.Where(k => lower.Contains(k)).ToList();
            foreach (var chakra in chakraMatches)
            {
                pieces.Add(Chakras[chakra]);
            }

            // 6. Detect dream symbols
            var dreamMatches = DreamSymbols.Keys.Where(k => lower.Contains(k)).ToList();
            foreach (var symbol in dreamMatches)
            {
                pieces.Add(DreamSymbols[symbol]);
            }

            bool mentionsShadow = ShadowKeywords.Any(k => lower.Contains(k));
            bool isAboutRisingSign = lower.Contains("rising") || lower.Contains("ascendant");
            bool isAboutMoonSign = lower.Contains("moon sign");
            bool isAboutSunSign = lower.Contains("sun sign");
            bool asksMeaning = lower.Contains("mean") || lower.Contains("meaning") || lower.Contains("represent");

            // If no specific matches, go into intuitive mode
            if (!pieces.Any())
            {
                return BuildIntuitiveResponse(q, mentionsShadow);
            }

            // Build a fused response
            return BuildFusedResponse(q, pieces, mentionsShadow, isAboutRisingSign, isAboutMoonSign, isAboutSunSign, asksMeaning);
        }

        private static string BuildFusedResponse(
            string question,
            List<string> pieces,
            bool mentionsShadow,
            bool isAboutRising,
            bool isAboutMoon,
            bool isAboutSun,
            bool asksMeaning)
        {
            var response = new List<string>();

            // Intro — acknowledge question
            response.Add(
                "You brought a thoughtful question, and the symbols you’re circling hold more layers than they show at first glance. Let’s unfold them slowly and see what they’re really pointing to in you.");

            // Core symbolic pieces
            response.Add(
                "First, let’s look at the core energies present in what you asked. Each symbol, placement, or archetype is like a facet of a larger mirror — together they form a picture of where you are and what your soul is working with right now.");

            // Summarize detected meanings
            response.Add(string.Join("\n\n", pieces));

            // Rising / Moon / Sun nuance
            if (isAboutRising)
            {
                response.Add(
                    "When you ask about your rising sign or Ascendant, you’re really asking about the way you move through the world on first contact — the mask, the armor, and the instinctive posture your energy takes. It’s less about who you are in private and more about how life tends to meet you at the door.");
            }

            if (isAboutMoon)
            {
                response.Add(
                    "Your Moon sign is not just a fun detail; it describes the emotional climate inside your chest. It speaks to what your nervous system longs for, how you self‑soothe, and the kinds of experiences that feel like home — even when your mind insists otherwise.");
            }

            if (isAboutSun)
            {
                response.Add(
                    "Your Sun sign is the long arc of becoming — not just your identity, but the ongoing story of how you grow into your own light. Often the Sun’s lessons don’t feel comfortable at first; they are the muscles you build over time.");
            }

            // Meaning / integration
            if (mentionsShadow || ShadowKeywords.Any(k => question.ToLowerInvariant().Contains(k)))
            {
                response.Add(
                    "There is also a clear thread of shadow‑work woven into what you’re asking. Shadow here doesn’t mean something ‘bad’ or broken in you — it refers to the parts of you that had to go underground to keep you safe, loved, or accepted. These symbols are gently pointing toward patterns, fears, or old stories that are ready to be seen with more compassion.");
            }

            if (asksMeaning)
            {
                response.Add(
                    "So when you ask what all of this really ‘means,’ we can say this: it is less about a fixed fate and more about an invitation. These placements and archetypes describe a landscape of tendencies and lessons — but you are still the one walking the path, choosing how consciously to engage with them.");
            }

            // Gentle guidance / next steps
            response.Add(
                "If you sit with this, notice where your body reacts — the symbol, sign, or sentence that hits a little harder or lingers a bit longer. That is usually where the real work and real magic live: the tender edge where you are both afraid of and drawn toward your own power.");

            response.Add(
                "From here, a simple practice: write down the main symbols that stood out to you from this reading. Next to each one, note both a fear it might be mirroring and a strength it might be awakening. That balance — naming both the wound and the gift — is how you slowly bring shadow material back into conscious, loving awareness.");

            response.Add(
                "You are not behind. You are not missing your moment. You are in the middle of a conversation with your own soul, and these archetypes are just the language it’s using today. When you’re ready, you can always ask a more specific question, and we’ll go deeper into one thread at a time.");

            return string.Join("\n\n", response);
        }

        private static string BuildIntuitiveResponse(string question, bool mentionsShadow)
        {
            var lower = question.ToLowerInvariant();
            var response = new List<string>();

            response.Add(
                "Even without clear astrological or tarot symbols named, the way you framed your question carries its own energy — a mix of longing, uncertainty, and a quiet desire to understand yourself more honestly.");

            if (mentionsShadow || ShadowKeywords.Any(k => lower.Contains(k)))
            {
                response.Add(
                    "There is a strong shadow‑work note here. Shadow‑work isn’t about digging for pain just to suffer; it’s about noticing where you’ve had to split off parts of yourself to survive, and slowly inviting them back out of exile. Your question feels like a small door opening to those hidden rooms.");
            }
            else if (lower.Contains("dream") || lower.Contains("sleep"))
            {
                response.Add(
                    "Your dreams are not random — they’re a kind of nightly divination where your psyche speaks in symbols instead of sentences. Even if you don’t remember every detail, the emotional tone of your dreams is often a direct mirror of what you’re processing beneath the surface.");
            }
            else if (lower.Contains("stuck") || lower.Contains("lost") || lower.Contains("confused"))
            {
                response.Add(
                    "Feeling stuck or lost is often a sign that an old map has expired. The way you used to navigate life may no longer apply, not because you’ve failed, but because you’ve outgrown a former version of yourself.");
            }

            response.Add(
                "One thing that stands out in your question is the quiet courage it takes to even ask it. Most people numb out or distract themselves rather than turn toward their own patterns, fears, or longings. You’re already doing something different by naming this at all.");

            response.Add(
                "A gentle next step: instead of demanding a single ‘answer,’ try asking yourself, \"What is this feeling or pattern trying to protect in me?\" Often, defenses and repeating cycles started as a kind of makeshift safety. When you see the original purpose, it becomes easier to lovingly update the strategy.");

            response.Add(
                "You don’t have to decode everything at once. Start with what feels most alive in your question — the emotion or image that won’t let go — and treat it like a symbol in a chart or a card in a spread. Sit with it, write with it, breathe with it. The more you stay in honest conversation with yourself, the clearer the guidance becomes.");

            return string.Join("\n\n", response);
        }
    }
}
