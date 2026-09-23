#include <fstream>
#include <nlohmann/json.hpp>
using json = nlohmann::json;

void saveMagicFile(const std::string& path, const json& projectData) {
    std::ofstream file(path + ".magic");
    file << projectData.dump(4);
}

json loadMagicFile(const std::string& path) {
    std::ifstream file(path);
    json projectData;
    file >> projectData;
    return projectData;
}
