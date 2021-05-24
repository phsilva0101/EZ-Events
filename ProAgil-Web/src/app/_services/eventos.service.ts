import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Event } from '../_models/Event';

@Injectable({
  providedIn: 'root'
})
export class EventosService {

constructor(private http: HttpClient) { }
baseURL = 'http://localhost:5000/api/event'

getAllEvento(): Observable<Event[]> {
  return this.http.get<Event[]>(this.baseURL);
}

getEventsById(id: number) : Observable<Event>{
  return this.http.get<Event>(`${this.baseURL}/${id}`);
}

getEventsByTheme(theme: string): Observable<Event[]>{
  return this.http.get<Event[]>(`${this.baseURL}/getByTheme/${theme}`);
}
}
