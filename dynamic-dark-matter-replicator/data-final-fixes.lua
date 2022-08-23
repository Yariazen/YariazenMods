require ("scripts.recipe")

local exclude = {
	["used-up-uranium-fuel-cell"] = true,
}
for recipename,recipe in pairs(data.raw.recipe) do
	--[[
	if recipename == iron-chest then
		rawingredients(recipe, exclude)
	end
	]]

	local ret = rawingredients(recipe, exclude)

	log(serpent.block(rawingredients(recipe, exclude)))
end