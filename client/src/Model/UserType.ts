export interface UserRequest {
  name: string;
  password: string;
  email: string;
}

export type UserIdResponse = {
  userId: string;
};
