import { MockAuthService } from './mock-auth.service';

describe('Mock AuthService Testing', () => {
    let mockAuthService: MockAuthService;

    beforeEach(() => {
        mockAuthService = new MockAuthService();
    });

    afterEach(() => {
        mockAuthService = null;
    });

    it('auth service is initialized', () => {
        expect(mockAuthService).toBeDefined();
    });

    it('isAthenticated method testing -> without token', () => {
        expect(mockAuthService.isAuthenticated()).toBeFalsy();
    });

    it('isAthenticated method testing -> with token', () => {
        sessionStorage.setItem('token', 'dummy');
        expect(mockAuthService.isAuthenticated()).toBeTruthy();

        sessionStorage.clear();
        expect(mockAuthService.isAuthenticated()).toBeFalsy();

    });



});