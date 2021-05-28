const API_BASE_URL = `https://localhost:5002/`;

const getAbsolutePath = (relativePath: string) => {
  return `${API_BASE_URL}/${relativePath}`.replaceAll("\\", "/");
};

const ImageUtils = {
  getAbsolutePath,
};

export { ImageUtils };
