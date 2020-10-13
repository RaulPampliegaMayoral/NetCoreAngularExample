import { Item } from './item';

export class Shopping {
  id: number;
  name: string;
  user: string;
  created: Date;
  modified: Date;
  items: Item[];
}
