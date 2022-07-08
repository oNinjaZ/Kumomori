export interface BasketItem {
    bookId: number;
    author: string;
    title: string;
    description: string;
    pageCount: number;
    price: number;
    coverUrl: string;
    type: string;
    quantity: number;
    publishDate: Date;
}

export interface Basket {
    id: number;
    buyerId: string;
    items: BasketItem[];
}


