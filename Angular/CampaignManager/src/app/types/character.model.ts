import CharacterWeapon from "./characterWeapon.model";

export default interface Character {
  id: number;
  playerId: number;
  name: string;
  campaignId: number;
  characterWeapons: CharacterWeapon [];
  level: number;
  armorClass:number;
  hitPoints: number;
  race: string;
  alignment: string;
  class: string;
  image: string;
  strength: number;
  dexterity: number;
  constitution: number;
  intelligence: number;
  wisdom: number;
  charisma: number;

}
