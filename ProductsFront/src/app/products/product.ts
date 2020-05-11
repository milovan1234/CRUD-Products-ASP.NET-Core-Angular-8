export interface IProduct{
    id: number;
    productName: string;
    price: number;
    description: string;
}
export class Product implements IProduct{
    id: number;
    productName: string;
    price: number;
    description: string;
}