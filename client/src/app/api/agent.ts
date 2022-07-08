import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { history } from "../..";

const sleep = () => new Promise((resolve) => setTimeout(resolve, 500));

axios.defaults.baseURL = 'http://localhost:5000/api/';
axios.defaults.withCredentials = true;

const responseBody = (response: AxiosResponse) => response.data;

interface ErrorResponse {
    status?: number;
    title?: string;
    errors?: {
        [key: string]: string;
    };
    detail?: string
}

axios.interceptors.response.use(async response => {
    await sleep();
    return response;
}, (error: AxiosError) => {
    const { title, status, errors, detail } = error.response?.data as ErrorResponse;

    if (errors) {
        const modelStateErrors: string[] = [];
        for (const key in errors) {
            modelStateErrors.push(errors[key]);
        }
        throw modelStateErrors.flat();
    }

    switch (status) {
        case 400:
            toast.error(title);
            break;
        case 401:
            toast.error(title);
            break;
        case 500:
            history.push({
                pathname: '/server-error',
                state: { error: detail, title: title }
            });
            break;
        default:
            break;
    }
    return Promise.reject(error.response);
})

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody)
}

const Catalog = {
    list: () => requests.get('books'),
    details: (id: number) => requests.get(`books/${id}`),
}

const TestErrors = {
    get400Error: () => requests.get('buggy/bad-request'),
    get401Error: () => requests.get('buggy/unauthorized'),
    get404Error: () => requests.get('buggy/not-found'),
    get500Error: () => requests.get('buggy/server-error'),
    getValidationError: () => requests.get('buggy/validation-error'),
}

const Basket = {
    get: () => requests.get('basket'),
    addItem: (bookId: number, quantity = 1) => requests.post(`basket?bookId=${bookId}&quantity=${quantity}`, {}),
    removeItem: (bookId: number, quantity = 1) => requests.delete(`basket?bookId=${bookId}&quantity=${quantity}`)
}

const agent = {
    Catalog,
    TestErrors,
    Basket
}

export default agent;