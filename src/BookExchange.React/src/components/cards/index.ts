export * from "./books";
export * from "./posts";
export * from "./deals";
export * from "./requests";

export interface CardProps<TData> {
  cardItem: TData;
  action?: (id: number) => void;
  actionText?: string;
}
