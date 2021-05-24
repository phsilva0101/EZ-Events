import { SocialMedia } from "./SocialMedia";

export interface Speaker {
    id: number; 
    name: string; 
    description: string; 
    imageURL: string ; 
    phone : string; 
    email: string; 
    socialMedias: SocialMedia[]
    speakerEvents: Event[]
}