describe('A Demo Uni testing', () => {
    let expected: string;

    beforeEach(() => {
        expected = 'Hello world!';
    });


    afterEach(() => {
        expected = null;
    });

    it("First test case.", () => {
        expect('Hello world!').toEqual(expected);
    });
});