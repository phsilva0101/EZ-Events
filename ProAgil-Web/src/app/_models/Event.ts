import { Lot } from "./Lot";
import { SocialMedia } from "./SocialMedia";
import { Speaker } from "./Speaker";

export interface Event {
    id: number;    
    local: string;  
    theme: string; 
    amountOfPeople: number;  
    date: Date;  
    imagemURL: string; 
    phone: string;    
    email: string;  
    lots: Lot[]; 
    socialMedias: SocialMedia[];
    speakerEvents: Speaker[];
}

