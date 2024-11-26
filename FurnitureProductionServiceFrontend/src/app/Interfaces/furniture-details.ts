import { FurnitureItem } from "./furniture-item";

export interface FurnitureDetails extends FurnitureItem {
    description: string;
    width: number;
    depth: number;
    height: number;
    maximumLoad: number;
    weight: number;
  }
  