import { TestBed, ComponentFixture } from '@angular/core/testing';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ConfigService } from './shared/config.service';

describe('Testing App Component.', () => {
    let component: AppComponent;
    let fixture: ComponentFixture<AppComponent>;

    beforeEach(() => {
        
        // refine the test module by declaring the test component
        TestBed.configureTestingModule({
            declarations: [AppComponent],
            providers: [ConfigService, HttpClient, HttpHandler]
        });

        // create component and test fixture
        fixture = TestBed.createComponent(AppComponent);

        // get test component from the fixture
        component = fixture.componentInstance;

    });

    afterEach(() => {
        component = null;
    })


    it('should create component', () => {
        expect(component).toBeDefined();
    })


    it('should clean', () => {
        component.ngOnDestroy();
    })
});