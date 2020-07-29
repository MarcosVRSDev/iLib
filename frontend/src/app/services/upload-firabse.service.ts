import { AngularFireStorage, AngularFireStorageReference } from '@angular/fire/storage';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})


export class UploadFirebaseService {

  private basePath = '/images';
  private ref: AngularFireStorageReference;
  file: File;

  constructor(private afStorage: AngularFireStorage) { }

  handleFiles(event) {
    this.file = event.target.files[0];
  }

  uploadFile() {
    if (this.file) {
      const filePath = `${this.basePath}/${new Date().getTime()}_${Math.random().toString(36).substring(2)}`;
      this.ref = this.afStorage.ref(filePath);
      return this.ref.put(this.file);
    }
  }

  public getUrl() {
    return this.ref.getDownloadURL();
  }
}