import CharacterWeapon from "./characterWeapon.model";

export default interface Weapon {
  id: number;
  name: string;
  damage: string;
  range: number;
  description: string;
  characterWeapons: CharacterWeapon [];
}
