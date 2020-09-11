export interface UserModel {
    id: number,
    username: string;
    password: string;
    firstName?: string;
    lastName?: string;
    email?: string;
    mobile?: string;
}