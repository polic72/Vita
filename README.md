# Vita
A life simulator.

## Desired Features
Features marked by a + are features that will come in an upcoming update. The more +s, the further away.

- **Organism**
  - *Energy*: The energy an organism uses to do anything. Running out means death by starvation. Gain energy by eating.
  - *Health*: The health of the organism. Directly proportional to size. Decreased by being attacked. Can stay still and use energy to heal. Death if brought to zero.
  - *Direction*: The direction the organism is facing.
  - ++*Water*: How much water an organism has. Like a second energy but can only be gotten from drinking.
  - *Size*: The absolute size of the organism. Bigger = more health and slower speed all around. (Better temperature retention). Higher energy reserves.
  - +*Sensor*: Where the organism can sense stuff. Wider = less accurate. More acute = more accurate. Range goes up and down with width.
  - ++*Land Speed*: The speed an organism can move on land. This also accounts for turning speed. Higher speeds = higher energy cost.
  - ++*Water Speed*: The speed an organism can move in water. This also accounts for turning speed. Higher speeds = higher energy cost.
  - ++++*Air Speed*: The speed an organism can move in the air. This also accounts for turning speed. Higher speeds = higher energy cost. Any non-zero is rare and lowers health.
  - ++*Temperature*: Has min and max limits. Moving increases temp, staying still decreases. Too low = slower speeds, lowers health. Too high = higher energy costs of everything, higher water costs, lowers health.
  - +++*Mating*: Find another member of the same species and produce new offspring with them.
  - +*Corpse*: What’s left of an organism after they die. Can be a source of food, based on size.
  - *Intelligence*: Implement NEAT algorithm.
  - *Defence*: How much damage getting hit does to an attacker. Higher = lower speed.
  - *Attack*: How powerful an attack is. Higher attack = higher energy cost for attacking.
