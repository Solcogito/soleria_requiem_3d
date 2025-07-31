Soleria Requiem – Project Foundation Summary
Genre: 2D Side-Scroller inspired by Kingdom: Two Crowns
Core Idea: Units are AI-controlled via neural networks, and the player influences them indirectly through buildings and environment interactions.
Scale: Medium to large project with modular systems and runtime content.

🔧 PROFESSIONAL APPROACH OVERVIEW
✅ Asset Loading
Use Unity Addressables for all dynamic content (tiles, prefabs, units, VFX, audio).

Use a centralized AssetLoader class (wrapper) for clean async loading and releasing.

Handle in code:

Addressables.LoadAssetAsync<T>()

Dynamic spawning of units/buildings

Resource release logic

Editor Use:

Mark assets as Addressable in the Inspector

Organize them into groups with clear address names

✅ Tilemap & World
Use Unity's built-in Tilemap system for world layout.

Support procedural or code-generated tilemaps for dynamic zones.

Handle in code:

Tilemap generation (ground, zones, biomes)

Runtime placement of special tiles or obstacles

Editor Use:

Author test scenes, palette layouts

Assign tiles and tile types to Addressable groups

✅ AI & Neural Networks
Each unit has a UnitController, NeuralBrain, Sensor input layer, and Decision output layer.

Neural nets can be initialized via config or ScriptableObject.

Handle in code:

All AI logic (neural networks, decision layers, sensors, outputs)

Update loop and interaction with world data

Editor Use:

Assign base configs or ScriptableObjects to prefabs (weights, roles, types)

✅ Buildings & Influence System
Buildings emit influence zones or signals for AI units to sense.

Handle in code:

Influence propagation

Runtime instantiation and linking to AI systems

Editor Use:

Assign radius values, cost, and VFX via Inspector

Define structure templates via ScriptableObjects

✅ Scene & Game Flow
Use a persistent GameManager and SceneController

Runtime builds the world and loads Addressable content

Handle in code:

Scene transitions

World generation

Save/load flow

Editor Use:

Build prototype scenes for testing (e.g., DevScene, AI Test Arena)

✅ Prefabs
Prefabs are the base unit for everything (units, buildings, props)

Handle in code:

Runtime instantiation (via Addressables)

Setup/initialization logic (AI wiring, sensors, stats)

Editor Use:

Design prefabs with serialized fields

Assign visuals, components, and default configs

✅ Config & Data
Use ScriptableObjects or JSON for balancing, definitions, and neural weights.

Handle in code:

Parsing, interpretation, validation of configs

Editor Use:

Data entry via ScriptableObject fields (preferred over JSON unless needed for external editing)

🧠 Summary: What Goes in Code vs Editor
System	Handle in Code	Use the Editor For
Asset loading	Addressables.LoadAsync, wrappers	Marking assets as Addressable, grouping
World/tilemap gen	Ground/biome generation logic	Authoring palettes, test maps
Units & AI	Neural network logic, runtime decisions	Prefab setup, base AI configs
Buildings	Influence logic, runtime spawning	Prefab visuals, influence values
Game flow	Manager logic, runtime content flow	Initial scenes, basic layout
Data/config	Access & execution	ScriptableObject definitions

✅ Final Guideline
⚙️ Use code for logic, behavior, and runtime flexibility.
🧩 Use Unity’s Editor to configure, visualize, and speed up development.

This combo creates the most efficient, scalable, and professional Unity game architecture.

Let me know if you'd like a downloadable README.md version of this summary for your repo.
