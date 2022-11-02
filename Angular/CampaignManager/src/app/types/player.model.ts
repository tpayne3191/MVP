import Character from "./character.model";

export default interface Player {
  id: number;
  name: string;
  phone: string;
  email: string;
  city: string;
  characters?: Character [];
}
