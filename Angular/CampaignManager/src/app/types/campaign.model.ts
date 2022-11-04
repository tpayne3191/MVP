import Character from "./character.model";
export default interface Campaign {
  id: number;
  name: string;
  dateStarted: Date;
  dateEnded: Date;
  characters: Character;
}
