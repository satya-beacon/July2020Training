import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShellComponent } from './layout/shell/shell.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';


//import HttpClientModule 
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

//import user module
import { UserModule } from './user/user.module';

//import events module
import { EventsModule } from './events/events.module';


//import git module
import { GitHubModule } from './git/git-hub.module';


//import shared module
import { SharedModule } from './shared/shared.module';
import { AuthInterceptor } from './shared/http-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    ShellComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    SharedModule,
    UserModule,
    EventsModule,
    GitHubModule,
    AppRoutingModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass : AuthInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
