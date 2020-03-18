| Class ParkingLot : IParkingLot | Interaction |
| ------------------------------ | ----------- |
| Int ParkingID (PK)             |             |
| Int Length                     |             |
| Int? SpaceShipID               |             |
|                                |             |

| Class Person     | Interaction |
| ---------------- | ----------- |
| Int PersonID(PK) |             |
| string Name      |             |
| SpaceShipID(FK)  |             |
|                  |             |

| Class SpaceShip     | Interaction |
| ------------------- | ----------- |
| Int SpaceShipID(PK) |             |
| string Name         |             |
| int Length          |             |
|                     |             |

| Interface IParkingLot | Interaction |
| --------------------- | ----------- |
| Int ParkingID (PK)    |             |
| Int Length            |             |
| Int? SpaceShipID      |             |
|                       |             |