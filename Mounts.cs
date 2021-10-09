using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public enum MountType
    {
        QUEST_AND_CRAFT_MOUNTS,
        INGAME_PURCHASE,
        RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION,
        TRIBE_REPUTATION,
        ACHIEVEMENT,
        PROMOTIONAL
    }



    public class Mount
    {
        public Mount(string name, string description, MountType type)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public MountType MountType { get; set; }
    }

    public class AllMounts
    {
        public static Dictionary<MountType, string> MountTypeDescriptions = new Dictionary<MountType, string>()
        {
            { MountType.QUEST_AND_CRAFT_MOUNTS, "These mounts are obtained by completing quests and learning different crafting recipes."},
            { MountType.INGAME_PURCHASE, "Earn different in-game currencies by winning Triple Triad matches in the Gold Saucer, completing quests, and much more."},
            { MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION, "These mounts will prove to onlookers that you are not to be messed with. Complete numerous Extreme dungeons, trials, and FATEs for a shot at obtaining these creatures."},
            { MountType.TRIBE_REPUTATION, "There are many different tribes scattered across Eorzea, complete quests to earn their trust and currencies so you can purchase a mount from each vendor."},
            { MountType.ACHIEVEMENT, "Level up certain characters to the cap, or spend all your time crafting and gathering if you want a shot at obtaining these mounts."},
            { MountType.PROMOTIONAL, "Recruit friends to Final Fantasy XIV and complete in-game events to be rewarded with limited time mounts."}
        };

        public static Dictionary<string, string> EmoteMount = new Dictionary<string, string>()
        {
            {":garuda:", "Xanthos" },
            {":titan:", "Gullfaxi" },
            {":ifrit:", "Aithon" },
            {":ramuh:", "Markab" },
            {":shiva:", "Boreas" },
            {":levi:", "Enbarr" },
            {":nightm:", "Nightmare" },
            {":bisbird:", "White Lanner" },
            {":nidbird:", "Dark Lanner" },
            {":ravbird:", "Rose Lanner" },
            {":sephbird:", "Warring Lanner" },
            {":sophbird:", "Sophic Lanner" },
            {":thorbird:", "Round Lanner" },
            {":zurbird:", "Demonic Lanner" },
            {":crownof:", "Innocent Gwiber" },
            {":diamond:", "Diamond Gwiber" },
            {":emerald:", "Emerald Gwiber" },
            {":rubyw:", "Ruby Gwiber" },
            {":hade:", "Shadow Gwiber" },
            {":titania:", "Fae Gwiber" },
            {":byakko:", "Auspicious Kamuy" },
            {":lakshmi:", "Blissful Kamuy" },
            {":seiryu:", "Hallowed Kamuy" },
            {":shinryu:", "Legendary Kamuy" },
            {":susano:", "Reveling Kamuy" },
            {":suzaku:", "Euphonious Kamuy" },
            {":tsuku:", "Lunar Kamuy" },
            {":lightg:", "Gwiber Of Light" }
        };

        public static Dictionary<string, string> MountEmote = new Dictionary<string, string>()
        {
            { "Xanthos", ":garuda:"},
            { "Gullfaxi", ":titan:" },
            { "Aithon", ":ifrit:"  },
            { "Markab", ":ramuh:" },
            { "Boreas", ":shiva:" },
            { "Enbarr", ":levi:" },
            { "Nightmare", ":nightm:" },
            { "White Lanner", ":bisbird:" },
            { "Dark Lanner", ":nidbird:" },
            { "Rose Lanner", ":ravbird:" },
            { "Warring Lanner", ":sephbird:" },
            { "Sophic Lanner", ":sophbird:" },
            { "Round Lanner", ":thorbird:" },
            { "Demonic Lanner", ":zurbird:" },
            { "Innocent Gwiber", ":crownof:" },
            { "Diamond Gwiber", ":diamond:" },
            { "Emerald Gwiber", ":emerald:" },
            { "Ruby Gwiber", ":rubyw:" },
            { "Shadow Gwiber", ":hade:" },
            { "Fae Gwiber", ":titania:" },
            { "Auspicious Kamuy", ":byakko:" },
            { "Blissful Kamuy", ":lakshmi:" },
            { "Hallowed Kamuy", ":seiryu:" },
            { "Legendary Kamuy", ":shinryu:" },
            { "Reveling Kamuy", ":susano:" },
            { "Euphonious Kamuy", ":suzaku:" },
            { "Lunar Kamuy", ":tsuku:" },
            { "Gwiber Of Light", ":lightg:" }
        };

        private static List<Mount> MountList = new List<Mount>
        {
            new Mount("Black Chocobo", "A single-seater mount, obtain by completing the Main Scenario Quest Divine Intervention", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Ehll Tou", "A single-seater mount, obtain by completing the On Ehll Tou’s Wings side quest", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Firebird", " single-seater mount, obtain by completing the Fiery Wings, Fiery Hearts side quest (available after obtaining all the other Lanner mounts)", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Flying Chair", " single-seater mount, can be crafted by a Level 70 Alchemist with Master Alchemist V", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Kamuy of the Nine Tails", "A single-seater mount, obtain by completing the A Lone Wolf No More side quest (available after obtaining every Stormblood Extreme primal mount)", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Kirin", "A single-seater mount, obtain by completing the A Legend for a Legend side quest (available after obtaining all the other Nightmare mounts)", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Landerwaffe", "A two-seater mount, obtain by completing The Dragon Made side quest", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Magicked Card", "A single-seater mount, obtain by completing The Adventurer with All the Cards side quest", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Magicked Bed", "A single-seater mount, can be crafted by a Level 80 Carpenter with Master Carpenter VII", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Magitek Armor", "A single-seater mount, obtain by completing the Main Scenario Quest The Ultimate Weapon", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Manacutter", "A single-seater mount, obtain by completing the Main Scenario Quest Into the Aery", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Midgardsormr", "A single-seater mount, obtain by completing the Main Scenario Quest Fetters of Lament", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Polar Bear", "A single-seater mount, obtain by completing A Treat to Beat the Heat quest, Moonfire Faire (2021)", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Unicorn", "A single-seater mount, obtain by leveling a conjurer to level 30 completing the Side Quest Unicorn Power", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Yol", "A single-seater mount, obtain by completing the Main Scenario Quest In the Footsteps of Bardam the Brave", MountType.QUEST_AND_CRAFT_MOUNTS),
            new Mount("Adamantoise", "A single-seater mount, purchase for 200,000 MGP from the Gold Saucer Attendant", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Archon Throne", "A single-seater mount, purchase for 750,000 MGP from the Gold Saucer Attendant", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Big Shell", "A single-seater mount, exchange for 8,400 Skybuilders’ Scrips", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Fenrir", "A single-seater mount, purchase for 1,000,000 MGP from the Gold Saucer Attendant", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Korpokkur Kolossus", "A single-seater mount, purchase for 750,000 MGP from the Gold Saucer Attendant", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Sabotender Emperador", "A single-seater mount, purchase for 2,000,000 MGP from the Gold Saucer Attendant", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Typhon", "A single-seater mount, purchase for 750,000 MGP from the Gold Saucer Attendant", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Ahriman", "A single-seater mount, purchase for 6 Achievement Certificates from Jonathas in Old Gridania", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Behemoth", "A single-seater mount, purchase for 6 Achievement Certificates from Jonathas in Old Gridania", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Magitek Death Claw", "A single-seater mount, purchase for 6 Achievement Certificates from Jonathas in Old Gridania", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Antelope Doe", "A single-seater mount, available for 8,400 Skybuilders’ Scrips from Enie in The Firmament", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Antelope Stag", "A single-seater mount, purchased for 30 Fête Tokens from Enie in The Firmament", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Albino Karakul", "A single-seater mount, purchase for 8,400 Skybuilders’ Scrips from Enie in The Firmament", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Megalotragus", "A single-seater mount, purchase for 8,400 Skybuilders’ Scrips from Enie in The Firmament", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Pegasus", "A single-seater mount, purchase for 4,200 Skybuilders’ Scrips from Enie in The Firmament", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Ufiti", "A single-seater mount, purchase for 8,400 Skybuilders’ Scrips from Enie in The Firmament", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Auspicious Kamuy", "A single-seater mount, purchase for 99 Byakko Totems from Eschina in Rhalgr’s Reach. This mount is also a random drop after completing The Jade Stoa (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Blissful Kamuy", "A single-seater mount, purchase for 99 Bliss Totems from Eschina in Rhalgr’s Reach. This mount is also a random drop after completing Emanation (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Euphonious Kamuy", "A single-seater mount, purchase for 99 Suzaku Totems from Eschina in Rhalgr’s Reach. This mount is also a random drop after completing Hells’ Kier (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Hallowed Kamuy", "A single-seater mount, purchase for 99 Seiryu Totems from Eschina in Rhalgr’s Reach. This mount is also a random drop after completing The Wreath of Snakes (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Legendary Kamuy", "A single-seater mount, purchase for 99 Shinryu Totems from Eschina in Rhalgr’s Reach. This mount is also a random drop after completing The Minstrel’s Ballad: Shinryu’s Domain", MountType.INGAME_PURCHASE),
            new Mount("Lunar Kamuy", "A single-seater mount, purchase for 99 Lunar Totems from Eschina in Rhalgr’s Reach. This mount is also a random drop after completing The Minstrel’s Ballad: Tsukuyomi’s Pain", MountType.INGAME_PURCHASE),
            new Mount("Reveling Kamuy", "A single-seater mount, purchase for 99 Revel Totems from Eschina in Rhalgr’s Reach. This mount is also a random drop after completing The Pool of Tribute (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Dark Lanner", "A single-seater mount, purchase for 99 Horde Totems from Bertana in Idyllshire. This mount is also a random drop after completing The Minstrel’s Ballad: Nidhogg’s Rage", MountType.INGAME_PURCHASE),
            new Mount("Demonic Lanner", "A single-seater mount, purchase for 99 Demon Totems from Bertana in Idyllshire. This mount is also a random drop after completing the Containment Bay Z1T9 (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Rose Lanner", "A single-seater mount, purchase for 99 Hive Totems from Bertana in Idyllshire. This mount is also a random drop after completing Thok ast Thok (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Round Lanner", "A single-seater mount, purchase for 99 Heavens’ Ward Helm Fragments from Bertana in Idyllshire. This mount is also a random drop after completing The Minstrel’s Ballad: Thordan’s Reign", MountType.INGAME_PURCHASE),
            new Mount("Sophic Lanner", "A single-seater mount, purchase for 99 Goddess Totems from Bertana in Idyllshire. This mount is also a random drop after completing the Containment Bay P1T6 (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Warring Lanner", "A single-seater mount, purchase for 99 Fiend Totems from Bertana in Idyllshire. This mount is also a random drop after completing the Containment Bay S1T7 (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("White Lanner", "A single-seater mount, purchase for 99 Expanse Totems from Bertana in Idyllshire. This mount is also a random drop after completing The Limitless Blue (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Fae Gwiber", "A single-seater mount, purchase for 99 King Totems from Fathard in Eulmore Aetheryte Plaza. This mount is also a random drop after completing The Dancing Plague (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Innocent Gwiber", "A single-seater mount, purchase for 99 Immaculate Totems from Fathard in Eulmore Aetheryte Plaza. This mount is also a random drop after completing Crown of the Immaculate (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Company Chocobo", "A single-seater mount, purchase for 200 Company Seals after joining one of the Grand Companies from The Immortal Flames, The Maelstrom or The Order of the Twin Adder vendor", MountType.INGAME_PURCHASE),
            new Mount("Construct 14", "A single-seater mount, purchase for 180 Bozjan Clusters from the Resistance Quartermaster in the Bozjan Southern Front", MountType.INGAME_PURCHASE),
            new Mount("Dhalmel", "A single-seater mount, can very rarely be won as a first place prize in the Kupo of Fortune", MountType.INGAME_PURCHASE),
            new Mount("Disembodied Head", "A single-seater mount, purchase for 10 Gelmorran Potsherds from E-Una-Kotor in the South Shroud at Quarrymill", MountType.INGAME_PURCHASE),
            new Mount("Forgiven Reticence", "A single-seater mount, purchase for 3,200 Sacks Of Nuts from Xylle at The Crystarium or Ilfroy at Eulmore", MountType.INGAME_PURCHASE),
            new Mount("Ironfrog Mover", "A single-seater mount, purchase for 12 Formidable Cogs from Fathard in Eulmore", MountType.INGAME_PURCHASE),
            new Mount("Ixion", "A single-seater mount, purchase for 12 Ixion Horns from Eschina in Rhalgr’s Reach", MountType.INGAME_PURCHASE),
            new Mount("Juedi", "A single-seater mount, speak to the Cast-off Confederate with all 4 Empyrean Accessories from Heaven-on-High in your inventory to obtain this mount", MountType.INGAME_PURCHASE),
            new Mount("Magitek Sky Armor", "A single-seater mount, purchase for 20,000 Wold Marks from Storm Sergeant in The Wolves’ Den", MountType.INGAME_PURCHASE),
            new Mount("Rathalos", "A single-seater mount, purchase for 50 Rathalos Scale+ from Smithy in Kugane. This mount is also a random drop after completing The Great Hunt (Extreme)", MountType.INGAME_PURCHASE),
            new Mount("Wyvern", "A single-seater mount, purchase for 6 Clan Mark Logs from Bertana in Idyllshire.", MountType.INGAME_PURCHASE),
            new Mount("Zu", "A single-seater mount, purchase for 1 Iron Voyage Spoil from any Resident Caretaker in", MountType.INGAME_PURCHASE),
            new Mount("Air Force", "A single-seater mount, guaranteed to drop after completing Sigmascape V4.0 (Savage)", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Aithon", "A single-seater mount, obtain by completing The Bowl Of Embers (Extreme), not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Alte Roite", "A single-seater mount, guaranteed to drop after completing Deltascape V4.0 (Savage)", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Arrhidaeus", "A single-seater mount, guaranteed to drop after completing Alexander: The Soul of the Creator (Savage)", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Black Pegasus", "A single-seater mount, obtain from Gold-trimmed Sacks on Floors 151-200 of the Palace of the Dead, not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Boreas", "A single-seater mount, obtain by completing The Akh Afah Amphitheatre (Extreme), not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Construct VI-S", "A single-seater mount, part of the Unreal trials and Faux Hollows minigame – exchange 600 faux leaves for this mount", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Cerberus", "A single-seater mount, obtain by completing Delubrum Reginae (Savage)", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Deinonychus", "A single-seater mount, obtain by completing the Dalriada raid, in the final boss chest", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Diamond Gwiber", "A single-seater mount, obtain by completing The Cloud Deck (Extreme) raid", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Dodo", "A single-seater mount, obtain from Platinum-haloed Sacks on Floors 71-100 of Heaven-on-High, not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Eden", "A single-seater mount, obtain by completing the Eden Promise: Eternity (Savage) raid", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Eldthurs", "A single-seater mount, obtain from Gold Coffers in Eureka Pyros or Silver Bunny Coffers in Pyros, not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Emerald Gwiber", "A single-seater mount, obtain by completing Castrum Marinum (Extreme) trial", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Enbarr", "A single-seater mount, obtain by completing The Whorleater (Extreme), not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Eurekan Petrel", "A single-seater mount, obtain from Gold Coffers in Eureka Hydatos, not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Gabriel α", "A single-seater mount, obtain from Southern Front Lockboxes in The Bozjan Southern Front, not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Gabriel Mark III", "A single-seater mount, obtain by completing the Delubrum Reginae raid on normal", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Gobwalker", "A single-seater mount, guaranteed to drop after completing Alexander: The Burden of the Father (Savage)", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Gullfaxi", "A single-seater mount, obtain by completing The Navel (Extreme), not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Gwiber of Light", "A single-seater mount, obtain by completing The Seat of Sacrifice (Extreme), not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Magitek Predator", "A single-seater mount, obtain by completing Ala Mhigo (Dungeon), not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Markab", "A single-seater mount, obtain by completing The Striking Tree (Extreme), not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Model O", "A single-seater mount, guaranteed to drop after completing Alphascape V4.0 (Savage)", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Nightmare", "A single-seater mount, obtain by completing The Howling Eye (Extreme), The Navel (Extreme), or The Bowl of Embers (Extreme), not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Ramuh", "A single-seater mount, guaranteed to drop after completing Eden’s Verse: Refulgence (Savage)", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Ruby Gwiber", "A single-seater mount, randomly drops during Cinder Drift (Extreme)", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Shadow Gwiber", "A single-seater mount, obtain by completing The Minstrel’s Ballad: Hades’s Elegy, not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Skyslipper", "A single-seater mount, guaranteed to drop after completing Eden’s Gate: Sepulture (Savage)", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Tyrannosaur", "A single-seater mount, obtain from Anemos Lockboxes, which are obtained by completing FATEs in Eureka Anemos, not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Xanthos", "A single-seater mount, obtain by completing The Howling Eye (Extreme), not a guaranteed drop", MountType.RAID_TRIAL_DUNGEON_AND_FATE_COMPLETION),
            new Mount("Bomb Palanquin", "A single-seater mount, purchase for 120,000 gil from the Kobold Vendor after achieving Trusted reputation with the Kobold Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Cavalry Drake", "A single-seater mount, purchase for 120,000 gil from the Amalj’aa Vendor after achieving Trusted reputation with the Amalj’aa Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Cavalry Elbst", "A single-seater mount, purchase for 120,000 gil from the Sahagin Vendor after achieving Trusted reputation with the Sahagin Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Cloud Mallow", "A single-seater mount, purchase for 200,000 gil from Mogmul Mogbelly in The Churning Mists after achieving Sworn reputation with the Moogle Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Direwolf", "A single-seater mount, purchase for 120,000 gil from Ixali Trader in North Shroud after achieving Sworn reputation with the Ixali Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Gilded Mikoshi", "A single-seater mount, purchase from Edelina in Mor Dhona for 50,000,000 gil", MountType.TRIBE_REPUTATION),
            new Mount("Great Vessel Of Ronka", "A single-seater mount, purchase for 18 Qitari Compliments from Yuqurl Manl in Rak’tika Greatwood after achieving Sworn reputation with the Qitari Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Kongamato", "A single-seater mount, purchase for 200,000 gil from Vath Stickpeddler after achieving Sworn reputation with the Vath Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Laurel Goobbue", "A single-seater mount, purchase for 120,000 gil from the Sylphic Vendor after achieving Trusted reputation with the Sylph Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Marid", "A single-seater mount, purchase for 18 Ananta Dreamstaff’s from Madhura in Gyr Abania after achieving Sworn reputation with the Ananta Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Mikoshi", "A single-seater mount, purchase for 20 Namazu Koban’s from Gyosho in The Azim Steppe after achieving Sworn reputation with the Namazu Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Portly Porxie", "A single-seater mount, purchase for 18 Fae Fancies from Jul Oul in Il Mheg after achieving Sworn reputation with the Pixie Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Resplendent Vessel Of Ronka", "A single-seater mount, purchase from Tabeth in Eulmore for 25,000,000 gil", MountType.TRIBE_REPUTATION),
            new Mount("Rolling tankard", "A single-seater mount, purchase for 18 Hammered Frogment from Mizutt in Lakeland after achieving Sworn reputation with the Dwarf Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Sanuwa", "A single-seater mount, purchase for 200,000 gil from Luna Vanu in The Sea of Clouds after achieving Sworn reputation with the Vanu Vanu Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Striped Ray", "A single-seater mount, purchase for 12 Kojin Sango from Shikitahe in The Ruby Sea after achieving Bloodsworn reputation with the Kojin Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("True Griffin", "A single-seater mount, purchase for 18 Ananta Dreamstaff from Madhura in Gyr Abania after achieving Bloodsworn reputation with the Ananta Beast Tribe", MountType.TRIBE_REPUTATION),
            new Mount("Astrope", "A two-seater mount, receive by completing the I Hope Mentor Will Notice Me VI achievement", MountType.ACHIEVEMENT),
            new Mount("Aerodynamics system", "A single-seater mount, receive by completing the In a Blaze Of Glory V achievement", MountType.ACHIEVEMENT),
            new Mount("Al-iklil", "A two-seater mount, receive by completing the A Complete History achievement", MountType.ACHIEVEMENT),
            new Mount("Amaro", "A single-seater mount, receive by completing the A Life of Adventure IV achievement", MountType.ACHIEVEMENT),
            new Mount("Battle Bear", "A single-seater mount, receive by completing the Tank You, Warrior III achievement", MountType.ACHIEVEMENT),
            new Mount("Battle Lion", "A single-seater mount, receive by completing the Tank You, Paladin III achievement", MountType.ACHIEVEMENT),
            new Mount("Battle Panther", "A single-seater mount, receive by completing the Tank You, Dark Knight III achievement", MountType.ACHIEVEMENT),
            new Mount("Battle Tiger", "A single-seater mount, receive by completing the Tank You, Gunbreaker III achievement", MountType.ACHIEVEMENT),
            new Mount("Centurio tiger", "A single-seater mount, receive by completing the You Got Game achievement", MountType.ACHIEVEMENT),
            new Mount("Construct VII", "A single-seater mount, receive by completing the One Steppe At A Time V achievement", MountType.ACHIEVEMENT),
            new Mount("Demi Ozma", "A single-seater mount, receive by completing the We’re on Your Side I achievement", MountType.ACHIEVEMENT),
            new Mount("Flame Warsteed", "A single-seater mount, receive by completing the A Line in the Sand IV achievement", MountType.ACHIEVEMENT),
            new Mount("Gilded Magitek", "A single-seater mount, receive by completing the Everybody’s Darling achievement", MountType.ACHIEVEMENT),
            new Mount("Ginga", "A single-seater mount, receive by completing the Frontline Fury achievement", MountType.ACHIEVEMENT),
            new Mount("Gloria-class Airship", "A single-seater mount, receive by completing the You Are What You Eat IV achievement", MountType.ACHIEVEMENT),
            new Mount("Goten", "A single-seater mount, receive by completing the Fatal Feast achievement", MountType.ACHIEVEMENT),
            new Mount("Hybodus", "A single-seater mount, receive by completing the No More Fish in the Sea II achievement", MountType.ACHIEVEMENT),
            new Mount("Logistics System", "A single-seater mount, receive by completing the Behind Enemy Lines I achievement", MountType.ACHIEVEMENT),
            new Mount("Magitek Avenger", "A single-seater mount, receive by completing the Die Another Day III achievement", MountType.ACHIEVEMENT),
            new Mount("Magitek Avenger A1", "A single-seater mount, receive by completing the Out of Hiding achievement", MountType.ACHIEVEMENT),
            new Mount("Morbol", "A single-seater mount, receive by completing the True Blue achievement", MountType.ACHIEVEMENT),
            new Mount("Parade Chocobo", "A single-seater mount, receive by completing the Leaving a Better Impression II achievement", MountType.ACHIEVEMENT),
            new Mount("Pteranodon", "A single-seater mount, receive by completing the Castle in the Sky achievement", MountType.ACHIEVEMENT),
            new Mount("Raigo", "A single-seater mount, receive by completing the Furious Fatalities achievement", MountType.ACHIEVEMENT),
            new Mount("Safeguard System", "A single-seater mount, receive by completing the Front and Center V achievement", MountType.ACHIEVEMENT),
            new Mount("Serpent Warsteed", "A single-seater mount, receive by completing the A Line in the Glade IV achievement", MountType.ACHIEVEMENT),
            new Mount("Storm Warsteed", "A single-seater mount, receive by completing the A Line in the Storm IV achievement", MountType.ACHIEVEMENT),
            new Mount("Triceratops", "A single-seater mount, receive by completing the Nuts for Nutsy achievement", MountType.ACHIEVEMENT),
            new Mount("War Panther", "A single-seater mount, receive by completing the But Somebody’s Gotta Do It(Dark Knight) achievement", MountType.ACHIEVEMENT),
            new Mount("War Tiger", "A single-seater mount, receive by completing the Tank You, Gunbreaker II achievement", MountType.ACHIEVEMENT),
            new Mount("Warbear", "A single-seater mount, receive by completing the But Somebody’s Gotta Do It(Warrior) achievement", MountType.ACHIEVEMENT),
            new Mount("Warlion", "A single-seater mount, receive by completing the But Somebody’s Gotta Do It(Paladin) achievement", MountType.ACHIEVEMENT),
            new Mount("Amber Draught Chocobo", "A two-seater mount, purchase for 8 Gold Chocobo Feathers from any Calamity Salvager.You receive Gold Chocobo Feathers through the Recruit a Friend campaign", MountType.PROMOTIONAL),
            new Mount("Chocorpokkur", "A promotional chocolate mount, part of a Butterfinger campaign.Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Draught Chocobo", "A two-seater mount, obtain by recruiting a friend to A Realm Reborn through the Recruit a Friend Campaign.You will obtain the Draught Chocobo after the friend you refer subscribes for 90 days", MountType.PROMOTIONAL),
            new Mount("Managarm", "A single-seater mount, purchase for 8 Gold Chocobo Feathers from any Calamity Salvager.You receive Gold Chocobo Feathers through the Recruit a Friend campaign", MountType.PROMOTIONAL),
            new Mount("Twintania", "A single-seater mount, purchase for 15 Gold Chocobo Feathers from any Calamity Salvager.You receive Gold Chocobo Feathers through the Recruit a Friend campaign", MountType.PROMOTIONAL),
            new Mount("Circus Ahriman", "A single-seater mount, obtained as a reward for completing the Seasonal Event Quest, Fear and Delight during All Saints’ Wake (2019). Unfortunately no longer available.", MountType.PROMOTIONAL),
            new Mount("Coeurl", "A single-seater mount, given to players with the Collector’s Edition or Digital Collector’s Edition of A Realm Reborn.", MountType.PROMOTIONAL),
            new Mount("Fat Chocobo", "A single-seater mount, given to players with the Collector’s Edition or Digital Collector’s Edition of A Realm Reborn.", MountType.PROMOTIONAL),
            new Mount("Griffin", "A single-seater mount, given to players with the Collector’s Edition or Digital Collector’s Edition of Heavensward.", MountType.PROMOTIONAL),
            new Mount("Grani", "A single-seater mount, given to players with the Collector’s Edition or Digital Collector’s Edition of Shadowbringers.", MountType.PROMOTIONAL),
            new Mount("Syldra", "A single-seater mount, given to players with the Collector’s Edition or Digital Collector’s Edition of Stormblood.", MountType.PROMOTIONAL),
            new Mount("Falcon", "A single-seater mount, obtained as a reward for completing Fly the Falcon Mount Campaign or the Mythology Moogle Treasure Trove event. Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Fat Black Chocobo", "A single-seater mount, obtained by spending $20 or more on video games on Amazon during a promotion that was held June 16, 2019 – July 1, 2019. Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Flying Cumulus", "A single-seater mount, obtained by spending $20 or more on video games on Amazon during a promotion that was held April 25, 2017 – May 8, 2017. Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Original Fat Chocobo", "A single-seater mount, obtained by spending $20 or more on video games on Amazon during a promotion that was held June 14, 2016 – July 4, 2016. Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Goobbue", "A single-seater mount, it was rewarded to anyone that played the 1.0 version of Final Fantasy XIV. Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Legacy Chocobo", "A single-seater mount, it was rewarded to anyone that played the 1.0 version of Final Fantasy XIV. Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Lone Hellhound", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast (Season 3). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Pack Hellhound", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast(Season 3). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Prototype Roader", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast(Season 17). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Lone Faehound", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast(Season 4). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Pack Faehound", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast(Season 4). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Magitek Conveyor", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast(Season 7). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Prototype Conveyor", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast(Season 8). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Magna Roader", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast(Season 11). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Maxima Roader", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast(Season 12). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Epimetheus", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast(Season 14). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Menoetius", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast(Season 15). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Magitek Hyperconveyor", "A single-seater mount, it was rewarded to the Top 100 players of each data center at the end of The Feast(Season 16). Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Regalia Type G", "A four-seater mount, purchased for 200,000 MGP from the Ironworks Vendor in The Gold Saucer during the Collaboration Event, A Nocturne for Heroes.Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Snowman", "A single-seater mount, available in the Starlight Celebration(2020). Unfortunately no longer available.", MountType.PROMOTIONAL),
            new Mount("Jibanyan Couch", "A single-seater mount, it was awarded to players that completed the More Inventory Slots, Please II achievement, during the Yo-kai Watch: Gather One, Gather All! event. Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Whisper A-Go-Go", "A single-seater mount, it was awarded to players that completed the More Inventory Slots, Please achievement, during the Yo-kai Watch: Gather One, Gather All! event. Unfortunately no longer available", MountType.PROMOTIONAL),
            new Mount("Whisper-Go", "A single-seater mount, it was awarded to players that completed the You Must Needs Befriend Them All achievement, during the Yo-kai Watch: Gather One, Gather All! event. Unfortunately no longer available", MountType.PROMOTIONAL)
        };


        private static Dictionary<string, Mount> Mounts;

        public static void InitMounts()
        {
            if (Mounts == null)
            {
                Mounts = new Dictionary<string, Mount>();

                foreach (var mount in MountList)
                {
                    if (!Mounts.ContainsKey(mount.Name))
                        Mounts.Add(mount.Name, mount);
                }
            }
        }

        public static Mount Get(string name)
        {
            InitMounts();

            if (Mounts.ContainsKey(name))
                return Mounts[name];

            return null;
        }

        public static List<Mount> Search(string name)
        {
            List<Mount> ret = new List<Mount>();
            for(int i = 0; i < MountList.Count; i++)
            {
                if (MountList[i].Name.Contains(name, StringComparison.OrdinalIgnoreCase) || MountList[i].Description.Contains(name, StringComparison.OrdinalIgnoreCase))
                    ret.Add(MountList[i]);
            }

            return ret;
        }

        public static IEnumerable<Mount> GetAll()
        {
            InitMounts();

            return Mounts.Values;
        }
    }
}
