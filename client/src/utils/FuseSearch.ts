import Fuse from "fuse.js";
import { listOfDbFoods } from "./ListOfDbFoods";

const fuseOptions: Fuse.IFuseOptions<{ title: string }> = {
  keys: ["title"],
  includeMatches: true,
  threshold: 0.3,
};
export const fuse = new Fuse(
  listOfDbFoods.map((food) => ({ title: food })),
  fuseOptions,
);
