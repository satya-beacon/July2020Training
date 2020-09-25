import { FooterComponent } from './footer.component';

describe('Footer Component testing.', () => {
    let component: FooterComponent;

    beforeEach(() => {
        component = new FooterComponent();
    });


    afterEach(() => {
        component = null;
    });

    it('should instantiate the footer', () => {
        expect(component).toBeDefined();
    });

    it('should validate properties.', () => {
        expect(component.year).toBeDefined();
        expect(component.year).toEqual(2020);

        component.year = 2000;
        expect(component.year).toEqual(2000);

        component.year = null;
        expect(component.year).toBeNull();
    });
});