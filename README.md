# MaidenLands
# Open world, open source, medieval fantasy RPG

## About
This is the primary repository for an open world, open source RPG **"MaidenLands"**.

**Welcome to Maiden Lands.**

Maiden Lands will be a community driven open world role playing game, where users can create their own stories, quests, characters and art and much more in a medieval fantasy world with a strong background story, theme, history, culture and lore.

The world of Maiden Lands will be filled with lots of interesting characters, towns, cities and stories, inspired by medieval Scandinavia, the world of "Maiden Lands" is divided into two lands masses with "Tribal Nord civilizations" to the north and "Saxons" in the "MaidenLands".

Maiden Lands has rich background, history of its civilizations, culture, historical events, architecture and a main story line as well as a  well defined protagonist and story characters.

Apart from main story line, tools will be developed free as well as exclusive to allow users to create content; from stories, quests and characters to locations and blacksmith and inventory items, the user created content can be sold to in game merchants and markets to other
users.

<img src="Resources/Maps/GRANADO_ESPADA_Sword_New_World.jpg" width="1000" height="600"/>

*__Please note that this is the first iteration of this document, mistakes or incomplete details are expected__*.
*__Give your feedback at ObaidurRehman164@gmail.com or like the facebook page https://www.facebook.com/MiadenLands-107453851032220.*

## Background and Story
Maiden Lands is filled with magic and monsters, both as humans and beasts.

In the year 1106, one after the other, Saxon kingdoms fell to Nordic invasions.
Saxon cities ravaged and plundered by pagans, populations killed and enslaved. Those who took refuge in deep forests found themselves and their families amongst
monsters, magic and outlaws, with no food and armies to defend themselves, thousands wew killed. Those who survived the forests and massacare took up arms and organised resistance movements through the MaidenLand.

Defenders of "A'Lia", a coastal city to the very end of MaidenLands, fought off the pagan invasion of 1106, the city resists the occupation forces even to this day.
The city has since become a symbol of hope and light to all the resistance movements spread across MaidenLands.

"A'Lia" also serves as the last political and mililtry hub for all Saxons, and organizes all resistance and mililtary movements to hold on to the remaining trade routes, settlements and natural resources across MaidenLand.

## Goals
The goal of this project is to create an immersive medieval fantasy world with a rich story, background, history and amazing art work, landscapes and vistas 
where users can create their own content as well; content such as quests, stories, locations and much more.
User created content can be sold and purchased to other users through markets and merchants in the "Maiden Lands".

## Will it help in some other way as well ?
1. Apart from a complete game, the goal of this project will be to develop an ***open source, plug and play, robust and complete game development framework for unity*** which will benefit anyone looking to develop their own game using unity as well as freelancers, small independent studios and start-ups, by providing them community driven battle tested tools.
2. Developers will have a chance to contribute and test their skills, those who will contribute will have their part of budget share, collected through donations and crowd-funding, (amount will base on a criteria).

## Art style & Concept art 
1. The game will have realistic art style in terms of terrain, vegetation, characters and other assets, the best example for this game's *__art style, lightning, mood and atmosphere is Remedy Entertainment's Alan wake.__*
Although this game is medieval themed and open world opposed to Alan wake however we can still use the art style, mood, lightning refrence of Alan wake, *__Alan wake provides a good exagratted day, evening, night time lightning and mood examples.__*

<img src="Resources/Art direction/01.jpg" width="300" height="300"/> <img src="Resources/Art direction/02.png" width="300" height="300"/> <img src="Resources/Art direction/03.jpg" width="300" height="300"/> <img src="Resources/Art direction/04.jpg" width="300" height="300"/> <img src="Resources/Art direction/05.jpg" width="300" height="300"/> <img src="Resources/Art direction/06.jpg" width="300" height="300"/> <img src="Resources/Art direction/07.jpg" width="300" height="300"/> <img src="Resources/Art direction/08.jpg" width="300" height="300"/> <img src="Resources/Art direction/09.jpg" width="300" height="300"/>

2. Initial vegetation assets, terrain/landscapes will be created by development team.
3. Officially art assets such as 3d models for villages, towns, castles, props, animations will be purchased from unity asset store, asset such as.

 - https://assetstore.unity.com/packages/3d/environments/historic/medieval-castle-model-7601.
 - https://assetstore.unity.com/packages/3d/environments/fantasy/viking-village-13921.

4. Programming will be completly done from scratch by the development team.
5. The world of "Maiden Land" is divided into two continents, and will have diverse landscapes features ranging from vast grass lands to snow covered montains, rivers and dense forests. In order to keep things constant and in harmony in terms of vegetation that grows in this land and physical features, the landscape of Russian is chosen.

<img src="Resources/Landscape/01.jpg" width="300" height="300"/> <img src="Resources/Landscape/02.jpg" width="300" height="300"/> <img src="Resources/Landscape/03.jpg" width="300" height="300"/> <img src="Resources/Landscape/04.jpg" width="300" height="300"/> <img src="Resources/Landscape/05.jpg" width="300" height="300"/> <img src="Resources/Landscape/06.jpg" width="300" height="300"/>
  
## Gameplay and game mechanics overview
The game is an open world RPG(Role playing game) played from third person point of view.

The main focus of the game world will not necessary be combat instead it will be story telling, immersion in the game world,
beautiful level designs and vistas however combat will still be an essential part of this game.

Apart from a immersive world there would be polished and well crafted mechanics such as.

- *inventory*
- *crafting*
- *branching dilogue*
- *branching stories*
- *dynamic day/night cycle*
- *intelligent NPCs*
- *exploration*
- *points of intrests*
- *and much more*

## Technical details overview
## World
1. The game will have a 32 square km world with various terrain/landscape features such as mountains, rivers, grass lands.
2. Dynamic day time and weather system.
3. Speed tree shaders provided by default by unity will be used for vegetation shaders.
4. Landscape will be procedurally generated using "World machine" and later fine detailed using unity's new terrain tools 
and terrain brushes.
5. A terrain system similar to Colormap Ultra Terrain Shader 4.0 will be used for terrain shading available on unity asset store, will be developed
for terrain shading.
https://assetstore.unity.com/packages/tools/terrain/colormap-ultra-terrain-shader-4-0-67260#description.
6. A procedural foilage distribution system will be developed for procedural vegetation scattering based on the following paper.
https://www.researchgate.net/publication/303973921_Procedural_Generation_of_Mediterranean_Environments.
You are welcomed to read the reserch paper.
7. Apart from procedural distribution of vegetation, custom terrain brushes and tools for foilage paiting on terrain will also be
developed.
8. Other useful and important tools such as road system for rapidly creation road/paths using splines,
object placement along a spline such as  fences will also be developed for production to make level design and world building as fast as
possible.

 ***a glimpse of tools that are being developed are for vegetation and foilage are as follows, they are inspired by cryengine foilage tools, and use clumps or
 patches for grass and ground cover( with proper height and mesh adjustment according to normal of terrain, topology and surface below) including bushes with the exception of trees***.
 ***Some of the tools being developed are***
 1. *Grass patch system.*
 2. *Rule based Geo paint tool (allows painting foilage or meshes such as debris on terrain as well as other meshes).*
 3. *Foilage area Tool, allow defining a fixed boundary area to grow or remove foilage into*
 4. *Splat map texturing tools for up to 8 textures.*
 5. *A foilage distribution system for entire terrain, based on paper mentioned above.*
 
 *although these tools are included in this repository, please keep in mind, that these tools are are not perfect yet, they are young and rough and need further,
 improvements, which is something I am working on*
 
 <img src="Resources/grassClump.png" width="1366" height="768"/>
 <img src="Resources/foilageArea.png" width="1366" height="768"/>
 <img src="Resources/geoPaint.png" width="1366" height="768"/>
 
 *video demostrations of above mentioned tools*
 
 1. https://www.youtube.com/watch?v=hBmHCbm6R_s.
 2. https://www.youtube.com/watch?v=zgq6685nBd0.
 3. https://www.youtube.com/watch?v=TtYiDVQB7jc.
 
## AI
1. GOAP or "goal oriented action planning" algorithm will be used for Non player characters(NPCs), decision making, the actual implementation of algorithm will be based on GOAP algorithm mentioned in this book
https://www.amazon.com/Programming-Example-Wordware-Developers-Library/dp/1556220782.
2. Unity builtin "NavMesh" will be used for NPC navigation.
3. AI agents/NPCs behavious will be divided into two categories.
  - Low level behaviours such as seek, flee, chase, hide, chat, gather, dialogue etc.
  - Low level behaviours are then grouped/arranged or executed in sequence to create more complex behaviours such as **go to forest and 
  **gather wood**, is a sequential execution of seek and gather wood, however more complex behaviours are also possible.
4. For AI/NPC sensory system(senses) a robust open source sensory system "UnitySensorySystem" will be used, however in order to 
integerate the "sensory system" into this project, the "sensory system" will require some minor modifications. The link to 
mentioned "sensory system"
https://github.com/ntk4/UnitySensorySystem.
5. Apart from above mentioned AI systems, custom systems are also created, info I have already created one, I have 
named it **_Location tool_**. The **_Location tool_** apart from other uses which I will mention it their respective categories, allows
creation of areas or location in a game world. With the help of this tool any location can be marked/converted to a location, the newly
created location is then be decorated with different useful properties such as the location's
- name
- location in game world
- important destionations in that location etc etc.
In the context of AI this information provided by **_Location tool_** is very important for example
- AI agents can be made aware of their current location in the game world e.g near **_old bear's inn_** or inside **_castle black_**.
- AI agents can poll locations during decision making phase, this is very important since more complex behaviours can be created
such as **_go to castle black_** or **_go to blacksmith and forge a sword_**.
This was just an overview of **_Location tool_**, however this tool is quite complex and it is not limited just to AI, more about this 
tool will be mentioned it their respective categories.

## Other
1. A graph system implementation will be used for a branching dilalogue, story as well as for quest editor, the implementation of graphs and other graphs related search algorithms will be based upon graphs implementation mentioned in this book
https://www.amazon.com/Programming-Example-Wordware-Developers-Library/dp/1556220782.

## Quest Editor 
We have big expectations in terms of "quests" for "Maiden Lands".
"__The quests will be 100% non-linear and can be completed in any more then one way__", quests will drive the story forward.
(More info comming soon).

## Timeline
Plan to finish off complete coding part of the game and world building is about 6 months, starting from **6/1/2020**, provided that the desired funding for the project is recieved. It will include 
1. Tools a fully detailed 32 square landscape with varing landscape features and vegetation will be available to general community.
2. Complete tools for gamers, level designers and artists to start populating the world, create stories, quests, towns, villages etc.
3. Game play mechanics.
4. Player mechanics.
5. World dynamics.

## MileStones and initial world building

- **Month 1-2 (vegetation and foilage system)**

Since the game take place in vast open landscapes, vegetation and foilage system will be the heart of all systems. Most of the basic tools included in vegetation 
system are almost complete however in order to make the vegetation system performance friendly as well, it will take time, I plan to give it a full complete month,
including writing all the manuals and making video tutorials. 

- **Month 2-3 (player and game mechanics)** 
  - character controllers
  - inventory system
  - crafting system
  - item loot system
  - dialogue system
  
- **Month 3-4 (developer tools)**
  - quest editor
  - story editor
  - tools to create and design levels such villages and towns
  - tools to add AI 
  
- **Month 4-5 (designing the world of Maiden Lands)**
  - landscapes
  - level design
  - art work
  - lightning
  - creating mood and atmosphere

- **Month 5-6 (further game mechanics)**
  - dynamic time of day
  - dynamic weather system
  - other game system
  - etc
  
- **Month 6-7 (fine tuning, polishing, testing)**
  - testing
  - video demostration by developers of various tools and systems
  
- **Month 7-8 (fine tuning previous steps)**
  - testing.
  - optional enhancements
  
## Donations / Crowd funding
I have spend past 7 to 8 months working full time on this ambitious project of mine, I worked on every single core aspect mostly technicals such as developing and making ready
the tool sets and framework to be used by other developers, however I have to pay for other aspects which are out of my domain such as concept art and art direction.
This project will also cost some part time developers as well, 

Initially I would require an immediate upfront amount of **500 US Dollars**, for 

1. Promotional and advertising art work and video for MaidenLands.

First short term amount, upfront amount of **5000$ US Dollars**, for various purposes such as 

1. centralize office.
2. hiring developers and artists.
3. paying part time developers.
4. for utility bills, etc.

Donations can be made using direct bank deposit or by becoming a patreon, both will earn rewards, benefits of contributions will be,

1. Access to Proprietary tools ( AI, Story editor and Quest editor ).
2. On demand tools.
3. On demand game mechanics.

**--> using western union**
1. National ID card number: 32203-0191179-8.
2. Mobile/Cell phone number: +923430285008.

**--> donations can be made by direct bank deposists**.
1. Account number: PK69BKIP0303400180820001.
2. Swift code: BKIPPKKA.

**--> or by becoming a patreon**.
- https://www.patreon.com/MaidenLands.

**--> a kick starter campaign (comming in second week of July)**.

**--> official twitter account (coming soon)**.


*For further queries / questions contact me directly*.
Contacts.

1. ObaidurRehman164@gmail.com.
2. https://www.facebook.com/obaid.rehman.1044/.
3. whatsapp +923430285008 
