export interface Book {
    id: number;
    author: string;
    title: string;
    description: string;
    pageCount: number;
    price: number;
    coverUrl: string;
    type: string;
    quantityInStock: number;
    publishDate: Date;
}