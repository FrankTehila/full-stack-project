export const fetchProducts = async () => {
    return new Promise((resolve) => {
        async () => {
            const response = await axios.post('http://localhost:5036/api/Meeting');
            const result = await response.json();
            resolve(result.products);
        };
    });
};

export const fetchProducts = async () => {

return new Promise(async (resolve) => {

try {

const response = await axios.post('http://localhost:5036/api/Meeting');

resolve(response.data.products);

} catch (error) {

console.error('Error fetching products:', error);

resolve([]);

}

});

};