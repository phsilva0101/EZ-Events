export interface Lot {
    id: number;
    name: string  ;

    price: number  ;

    initialDate?:Date;
    finalDate?: Date;

    amount: number;
    eventId: number;
    
}