import type { Product } from "./product";

export type Basket = {
  basketId: string;
  items: Item[];
};

export class Item {
  constructor(product: Product, quantity: number) {
    this.productId = product.id;
    this.name = product.name;
    this.price = product.price;
    this.pictureUrl = product.pictureUrl;
    this.brand = product.brand;
    this.quantity = quantity;
    this.type = product.type;
  }

  productId: number;
  name: string;
  price: number;
  pictureUrl: string;
  quantity: number;
  brand: string;
  type: string;
}
